using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using Microsoft.Crm.Sdk.Messages;
using Newtonsoft.Json;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace DependencySearch {
	public partial class DependencySearchControl : PluginControlBase {
		protected List<OptionSetLabel> ComponentTypes = new List<OptionSetLabel>();
		protected List<OptionSetLabel> DependencyTypes = new List<OptionSetLabel>();

		public DependencySearchControl() {
			InitializeComponent();

			cbRequest.Items.Add("RetrieveDependenciesForDeleteRequest");
			cbRequest.Items.Add("RetrieveDependenciesForUninstallRequest");
			cbRequest.Items.Add("RetrieveDependentComponentsRequest");

			btnExecute.Enabled = false;
			this.WorkAsync(new WorkAsyncInfo("Getting types...", (a) => {
				var comptypes = GetOptionSetValue("componenttype");
				ComponentTypes.AddRange(comptypes.Options.OrderBy(o => o.Label.LocalizedLabels.First().Label).Select(osv => new OptionSetLabel() {
					Id = osv.Value ?? -1,
					Name = osv.Label.LocalizedLabels.First().Label
				}));
				foreach (var c in ComponentTypes) {
					this.Invoke((MethodInvoker)delegate {
						cbType.Items.Add(c);
					});
				}
				var deptypes = GetOptionSetValue("dependencytype");
				DependencyTypes.AddRange(deptypes.Options.OrderBy(o => o.Label.LocalizedLabels.First().Label).Select(osv => new OptionSetLabel() {
					Id = osv.Value ?? -1,
					Name = osv.Label.LocalizedLabels.First().Label
				}));
			}));

		}

		public OptionSetMetadata GetOptionSetValue(string name) {
			try {
				var resp = this.ConnectionDetail.ServiceClient.Execute(new RetrieveOptionSetRequest() {
					Name = name
				});
				if (resp is RetrieveOptionSetResponse) {
					var rosr = resp as RetrieveOptionSetResponse;
					return (rosr.OptionSetMetadata as OptionSetMetadata);
				}
			}
			catch (Exception e) {
				this.Invoke((MethodInvoker)delegate {
					rtbResponse.Text = JsonConvert.SerializeObject(e, Formatting.Indented);
				});
			}
			finally {
				this.Invoke((MethodInvoker)delegate {
					btnExecute.Enabled = true;
				});
			}
			return null;
		}

		public void RequestThings() {
			try {
				int type = -1;
				string text = "";
				string req = "";

				this.Invoke((MethodInvoker)delegate {
					type = (cbType.SelectedItem as OptionSetLabel).Id;
					req = (string)cbRequest.SelectedItem;
					text = tbGuid.Text;
				});

					Microsoft.Xrm.Sdk.OrganizationRequest request = null;
				if (req == "RetrieveDependenciesForDeleteRequest") {
					request = new RetrieveDependenciesForDeleteRequest() {
						ObjectId = new Guid(text),
						ComponentType = type
					};
				}

				if (req == "RetrieveDependenciesForUninstallRequest") {
					request = new RetrieveDependenciesForUninstallRequest() {
						SolutionUniqueName = text,
					};
				}

				if (req == "RetrieveDependentComponentsRequest") {
					request = new RetrieveDependentComponentsRequest() {
						ObjectId = new Guid(text),
					};
				}

				var resp = this.ConnectionDetail.ServiceClient.Execute(request);
				this.Invoke((MethodInvoker)delegate {
					rtbResponse.Text = JsonConvert.SerializeObject(resp, Formatting.Indented);
					EntityCollection ec = null;
					if (resp is RetrieveDependenciesForDeleteResponse) {
						ec = (resp as RetrieveDependenciesForDeleteResponse).EntityCollection;
					}
					if (ec != null) {
						rtbResponse.Text = "";
						foreach (var entity in ec.Entities) {
							if (entity.LogicalName == "dependency") {
								//rtbResponse.Text += JsonConvert.SerializeObject(entity.Attributes, Formatting.Indented);
								//var dep = this.ConnectionDetail.ServiceClient.Retrieve("solutioncomponent", entity.GetAttributeValue<Guid>("dependentcomponentobjectid"), new Microsoft.Xrm.Sdk.Query.ColumnSet(true));
								var compType = ComponentTypes.FirstOrDefault(ct => ct.Id == entity.GetAttributeValue<OptionSetValue>("dependentcomponenttype").Value);
								var objId = entity.GetAttributeValue<Guid>("dependentcomponentobjectid");
								rtbResponse.Text += $"[{compType}] ";
								if (compType == ComponentTypes.FirstOrDefault(ct => ct.Name == "Workflow")) {
									var workflow = this.ConnectionDetail.ServiceClient.Retrieve("workflow", objId, new ColumnSet(true));
									rtbResponse.Text += ": '" + workflow.GetAttributeValue<string>("name") + "'";
								}
								rtbResponse.Text += $" {{{objId}}}" + Environment.NewLine;
							}
						}
						if (!ec.Entities.Any()) {
							rtbResponse.Text += "No Dependencies.";
						}
					}
					
				});
			}
			catch (Exception e) {
				this.Invoke((MethodInvoker)delegate {
					rtbResponse.Text = JsonConvert.SerializeObject(e, Formatting.Indented);
				});
			}
			finally {
				this.Invoke((MethodInvoker)delegate {
					btnExecute.Enabled = true;
				});
			}
		}

		private void btnExecute_Click(object sender, EventArgs e) {
			btnExecute.Enabled = false;
			if (tbGuid.Text.Any() && cbRequest.SelectedItem != null) {
				rtbResponse.Text = "";
				this.WorkAsync(new WorkAsyncInfo("Requesting...", (a) => {
					RequestThings();
				}));
			}
			else {
				rtbResponse.Text = "Please ensure you have an ID and Request Type set.";
				btnExecute.Enabled = true;
			}
		}
	}
}

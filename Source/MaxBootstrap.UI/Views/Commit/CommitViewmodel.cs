using MaxBootstrap.Core;
using MaxBootstrap.Core.View;
using LaunchAction = Microsoft.Tools.WindowsInstallerXml.Bootstrapper.LaunchAction;

namespace MaxBootstrap.UI.Views.Commit
{
    public class CommitViewmodel : ViewmodelBase, ICommitViewmodel
    {
        private string commitMessage;

        public CommitViewmodel(IBootstrapperController bootstrapperController, IView view)
            : base(bootstrapperController, view)
        {
            this.CommitMessage = "Error: Viewmodel not activated!";
        }

        public override void OnNavigatedTo()
        {
            switch (this.BootstrapperController.LaunchAction)
            {
                case LaunchAction.Install:
                    {
                        this.BootstrapperController.ViewController.ButtonStateManager.NextButton.Text = "Install";

                        this.CommitMessage = "Ready for installation, select 'Install' to begin installation";

                        break;
                    }
                case LaunchAction.Modify:
                    {
                        this.BootstrapperController.ViewController.ButtonStateManager.NextButton.Text = "Modify";

                        this.CommitMessage = "Ready for modifications, select 'Modify' to commit modifications";

                        break;
                    }
                case LaunchAction.Repair:
                    {
                        this.BootstrapperController.ViewController.ButtonStateManager.NextButton.Text = "Repair";

                        this.CommitMessage = "Ready for repair, select 'Repair' to commit to repairs";

                        break;
                    }
                case LaunchAction.UpdateReplace:
                    {
                        this.BootstrapperController.ViewController.ButtonStateManager.NextButton.Text = "Update";

                        this.CommitMessage = "Ready for update, select 'Update' to upgrade";

                        break;
                    }
                case LaunchAction.Uninstall:
                    {
                        this.BootstrapperController.ViewController.ButtonStateManager.NextButton.Text = "Uninstall";

                        this.CommitMessage = "Ready to uninstall, select 'Uninstall' to remove installation";

                        break;
                    }
                default:
                    {
                        this.BootstrapperController.ViewController.ButtonStateManager.NextButton.Text = "Commit";

                        this.CommitMessage = "Select 'Commit' to run '" + this.BootstrapperController.LaunchAction + '\'';

                        break;
                    }
            }
        }

        public string CommitMessage
        {
            get
            {
                return this.commitMessage;
            }

            set
            {
                this.commitMessage = value;
                this.NotifyPropertyChanged();
            }
        }
    }
}

using MaxBootstrap.Core.View;
using System.Collections.Generic;

namespace MaxBootstrap.Core.Pages
{
    public class ViewCollection
    {
        private readonly IDictionary<string, ViewActivator> viewActivatorDictionary;

        private IList<string> installSequence;

        private IList<string> upgradeSequence;

        private IList<string> modifySequence;

        private IList<string> repairSequence;

        private IList<string> uninstallSequence;

        public string StartPage { get; set; }

        public string ErrorPage { get; set; }

        public string CancelPage { get; set; }

        public ViewCollection()
        {
            this.viewActivatorDictionary = new Dictionary<string, ViewActivator>();
            this.installSequence = new List<string>();
            this.uninstallSequence = new List<string>();
            this.upgradeSequence = new List<string>();
            this.modifySequence = new List<string>();
            this.repairSequence = new List<string>();
        }

        public IView GetView(string pageID)
        {
            if (string.IsNullOrEmpty(pageID))
            {
                // TODO throw error or something
                return null;
            }

            if (this.viewActivatorDictionary.ContainsKey(pageID))
            {
                return this.viewActivatorDictionary[pageID].GetInstance();
            }

            // TODO Throw exception or at least log

            return null;
        }

        public void RegisterView<TPageConcrete>(IViewmodel viewmodel, bool maintainInstance = false)
        {
            this.RegisterView<TPageConcrete>(typeof(TPageConcrete).Name, viewmodel, maintainInstance);
        }

        public void RegisterView<TPageConcrete>(string pageID, IViewmodel viewmodel, bool maintainInstance = false)
        {
            if (!this.viewActivatorDictionary.ContainsKey(pageID))
            {
                this.viewActivatorDictionary[pageID] = new ViewActivator(typeof(TPageConcrete), viewmodel, maintainInstance);
            }
        }

        public void SetInstallSequence(IEnumerable<string> sequence)
        {
            this.SetSequence(sequence, this.installSequence);
        }

        public void SetUninstallSequence(IEnumerable<string> sequence)
        {
            this.SetSequence(sequence, this.uninstallSequence);
        }

        public void SetUpgradeSequence(IEnumerable<string> sequence)
        {
            this.SetSequence(sequence, this.upgradeSequence);
        }

        public void SetModifySequence(IEnumerable<string> sequence)
        {
            this.SetSequence(sequence, this.modifySequence);
        }

        public void SetRepairSequence(IEnumerable<string> sequence)
        {
            this.SetSequence(sequence, this.repairSequence);
        }

        public IEnumerable<string> InstallSequence
        {
            get
            {
                return this.installSequence;
            }
        }

        public IEnumerable<string> UpgradeSequence
        {
            get
            {
                return this.upgradeSequence;
            }
        }

        public IEnumerable<string> ModifySequence
        {
            get
            {
                return this.modifySequence;
            }
        }

        public IEnumerable<string> RepairSequence
        {
            get
            {
                return this.repairSequence;
            }
        }

        public IEnumerable<string> UninstallSequence
        {
            get
            {
                return this.uninstallSequence;
            }
        }

        private void SetSequence(IEnumerable<string> sequence, IList<string> pageList)
        {
            foreach (var pageName in sequence)
            {
                if (this.viewActivatorDictionary.ContainsKey(pageName))
                {
                    pageList.Add(pageName);
                }
                else
                {
                    // TODO Thow exception or something
                }
            }
        }
    }
}

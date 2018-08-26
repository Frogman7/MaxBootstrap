using System;
using System.Collections.Generic;

namespace MaxBootstrap.Core.View
{
    public class ViewCollection
    {
        private readonly IDictionary<string, IViewmodel> viewmodelDictionary;

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
            this.viewmodelDictionary = new Dictionary<string, IViewmodel>();

            this.installSequence = new List<string>();
            this.uninstallSequence = new List<string>();
            this.upgradeSequence = new List<string>();
            this.modifySequence = new List<string>();
            this.repairSequence = new List<string>();
        }

        public IViewmodel GetViewmodel(string viewmodelID)
        {
            if (string.IsNullOrEmpty(viewmodelID))
            {
                throw new ArgumentException("Viewmodel with given ID could not be found", nameof(viewmodelID));
            }

            if (!this.viewmodelDictionary.ContainsKey(viewmodelID))
            {
                throw new KeyNotFoundException("Viewmodel with viewmodel ID '" + viewmodelID + '\'');
            }

            return this.viewmodelDictionary[viewmodelID];
        }

        public void RegisterView<TPageConcrete>(IViewmodel viewmodel)
        {
            this.RegisterView<TPageConcrete>(typeof(TPageConcrete).Name, viewmodel);
        }

        public void RegisterView<TPageConcrete>(string pageID, IViewmodel viewmodel)
        {
            if (!this.viewmodelDictionary.ContainsKey(pageID))
            {
                this.viewmodelDictionary.Add(pageID, viewmodel);
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

        private void SetSequence(IEnumerable<string> sequence, IList<string> viewmodelList)
        {
            foreach (var viewmodelID in sequence)
            {
                if (this.viewmodelDictionary.ContainsKey(viewmodelID))
                {
                    viewmodelList.Add(viewmodelID);
                }
                else
                {
                    throw new KeyNotFoundException("Viewmodel required by sequence with page ID '" + viewmodelID + "' not found");
                }
            }
        }
    }
}

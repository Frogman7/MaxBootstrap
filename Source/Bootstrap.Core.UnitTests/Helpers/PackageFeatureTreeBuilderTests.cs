using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using MaxBootstrap.Core.Configuration;
using MaxBootstrap.Core.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace Bootstrap.Core.UnitTests.Helpers
{
    [TestClass]
    public class PackageFeatureTreeBuilderTests
    {
        [TestMethod]
        public void SimpleTreeBuild()
        {
            var packages = PackageFeatureTreeBuilder.BuildPackageTrees(this.buildPackageInfos(), this.buildFeatureInfos()).ToList();

            // Testing package 3
            var package3 = packages[2];
            Assert.IsTrue(package3.Features.Count() == 1);
            Assert.IsTrue(package3.Features.First().SubFeatureCount == 0);
        }

        [TestMethod]
        public void TestOrderedTreeBuild()
        {
            var treeBuilder = new PackageFeatureTreeBuilder();

            var packages = PackageFeatureTreeBuilder.BuildPackageTrees(this.buildPackageInfos(), this.buildFeatureInfos()).ToList();

            // Testing package 1
            var package1 = packages[0];
            Assert.IsTrue(package1.Features.Count() == 2);
            var features = package1.Features.ToList();
            Assert.IsTrue(features[0].SubFeatureCount == 0);
            Assert.IsTrue(features[1].SubFeatureCount == 5);
            features = features[1].SubFeatures.ToList();
            Assert.IsTrue(features[0].SubFeatureCount == 0);
            Assert.IsTrue(features[1].SubFeatureCount == 0);
            Assert.IsTrue(features[2].SubFeatureCount == 0);
            Assert.IsTrue(features[3].SubFeatureCount == 0);
            Assert.IsTrue(features[4].SubFeatureCount == 2);
        }

        [TestMethod]
        public void TestUnorderedTreeBuild()
        {
            var packages = PackageFeatureTreeBuilder.BuildPackageTrees(this.buildPackageInfos(), this.buildFeatureInfos()).ToList();

            // Testing package 2
            var package1 = packages[1];
            Assert.IsTrue(package1.Features.Count() == 1);
            var features = package1.Features.ToList();
            Assert.IsTrue(features[0].SubFeatureCount == 2);
            features = features[0].SubFeatures.ToList();
            Assert.IsTrue(features[0].SubFeatureCount == 1);
            Assert.IsTrue(features[1].SubFeatureCount == 0);
            features = features[0].SubFeatures.ToList();
            Assert.IsTrue(features[0].SubFeatureCount == 2);
        }

        private IEnumerable<PackageInfo> buildPackageInfos()
        {
            var packageInfos = new List<PackageInfo>();

            packageInfos.Add(new PackageInfo() { Id = "Package 1", Description = "First Package", DisplayName = "Package I" });
            packageInfos.Add(new PackageInfo() { Id = "Package 2", Description = "Second Package", DisplayName = "Package II" });
            packageInfos.Add(new PackageInfo() { Id = "Package 3", Description = "Third Package", DisplayName = "Package III" });

            return packageInfos;
        }

        private IEnumerable<FeatureInfo> buildFeatureInfos()
        {
            var featureInfos = new List<FeatureInfo>();

            // Package 1 Features, everything is sort of in descending order of most signifcant to least significant
            featureInfos.Add(this.BuildFeatureInfo("Package 1", "Soda", "The Soda Feature", "A 2 Litre of Soda", 874, string.Empty));
            featureInfos.Add(this.BuildFeatureInfo("Package 1", "Pizza", "The Pizza Feature", "A pizza", 1914, string.Empty));
            featureInfos.Add(this.BuildFeatureInfo("Package 1", "Pepperoni", "The Pepperoni Feature", "Processed meat", 812, "Pizza"));
            featureInfos.Add(this.BuildFeatureInfo("Package 1", "Mushroom", "The Mushroom Feature", "Fresh diced mushrooms", 315, "Pizza"));
            featureInfos.Add(this.BuildFeatureInfo("Package 1", "Olive", "The Olive Feature", "Diced black olives", 223, "Pizza"));
            featureInfos.Add(this.BuildFeatureInfo("Package 1", "Bell Pepper", "The Bell Pepper Feature", "Freshly chopped green bell peppers", 366, "Pizza"));
            featureInfos.Add(this.BuildFeatureInfo("Package 1", "Cheese", "The Cheese Feature", "Delious cheese", 644, "Pizza"));
            featureInfos.Add(this.BuildFeatureInfo("Package 1", "Mozzarella", "The Mozzarella Cheese Feature", "Mozzarella style cheese", 411, "Cheese"));
            featureInfos.Add(this.BuildFeatureInfo("Package 1", "Cheddar", "The Cheddar Cheese Feature", "Mozzarella style cheese", 397, "Cheese"));

            // Package 2 Features, kinda all over the place
            featureInfos.Add(this.BuildFeatureInfo("Package 2", "ExtraFonts", "The Extra Fonts Feature", "Adds additional fonts", 3472, "Plugins"));
            featureInfos.Add(this.BuildFeatureInfo("Package 2", "Plugins", "The Document Feature", "Adds Plugin Support", 9864, "Writer"));
            featureInfos.Add(this.BuildFeatureInfo("Package 2", "ExtraDocTypes", "The Extra Document Types Feature", "Adds support for additional document types", 2151, "Plugins"));
            featureInfos.Add(this.BuildFeatureInfo("Package 2", "Writer", "The Document Feature", "The document editor", 29513, "Office Suite"));
            featureInfos.Add(this.BuildFeatureInfo("Package 2", "Office Suite", "Product Features", "The base Office software", 4148554, string.Empty));
            featureInfos.Add(this.BuildFeatureInfo("Package 2", "Spreadsheet", "The Spreadsheet Feature", "The spreadsheet editor", 24119, "Office Suite"));

            // Package 3 Features, keeping it simple
            featureInfos.Add(this.BuildFeatureInfo("Package 3", "Product Features", "The Main Product Feature", "The product", 3472, string.Empty));

            return featureInfos;
        }

        private FeatureInfo BuildFeatureInfo(string packageId, string featureId, string title, string description, uint size, string parent, string directory = null)
        {
            return new FeatureInfo()
            {
                PackageId = packageId,
                FeatureId = featureId,
                Title = title,
                Description = description,
                Size = size,
                Parent = parent,
                Directory = directory ?? string.Empty
            };
        }
    }
}

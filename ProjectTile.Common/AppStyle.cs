using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTile.Common
{
    public class AppStyle
    {
        public AppStyle(int id, ApplicationInfo app)
            : this(id, app, false)
        {
        }

        public AppStyle(int id, ApplicationInfo app, bool isDefault)
        {
            if (app == null)
                throw new ArgumentNullException();

            this.ID = id;
            this.App = app;
            this.IsDefault = isDefault;
            this.VisualElements = new VisualElementsManifest();
        }


        public ApplicationInfo App { get; }

        public int ID { get; }

        public bool IsDefault { get; set; }

        public string Name { get; set; }

        public VisualElementsManifest VisualElements { get; set; }


        public static void SetCurrentIdentifier(int value)
        {
            IdentityGenerator.AddIdentityObject(typeof(AppStyle).FullName, value);
        }

        public static AppStyle Create(ApplicationInfo app, bool isDefault)
        {
            return new AppStyle(IdentityGenerator.GetNextID(typeof(AppStyle).FullName), app, isDefault);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ProjectTile.Common
{
    public class ApplicationInfo
    {
        public ApplicationInfo(int id)
        {
            this.ID = id;
            this.Styles = new List<AppStyle>();
        }
        

        public int ID { get; }

        public string ShortcutURI { get; set; }

        public string ExecutableURI { get; set; }

        public List<AppStyle> Styles { get; }


        public bool RemoveStyle(AppStyle item)
        {
            if (item.IsDefault)
                return false;

            return this.Styles.Remove(item);
        }


        public static void SetCurrentIdentifier(int value)
        {
            IdentityGenerator.AddIdentityObject(typeof(ApplicationInfo).FullName, value);
        }

        public static ApplicationInfo Create()
        {
            return new ApplicationInfo(IdentityGenerator.GetNextID(typeof(ApplicationInfo).FullName));
        }
    }
}

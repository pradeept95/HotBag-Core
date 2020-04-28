using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace HotBag.AspNetCore.Reflection
{
    /*
    *  Sealed restricts the inheritance
    */
    public sealed class AssemblyHelper
    {
        //Lazy initialization
        /*
        * Private property initilized with null
        * ensures that only one instance of the object is created
        * based on the null condition
        */
        private static readonly Lazy<AssemblyHelper> instance = new Lazy<AssemblyHelper>(() => new AssemblyHelper());

         
        /*
       * public property is used to return only one instance of the class
       * leveraging on the private property
       */
        public static AssemblyHelper Instance
        {
            get
            { 
                return instance.Value;
            }
        }

        /*
        * Private constructor ensures that object is not
        * instantiated other than with in the class itself
        */
        private AssemblyHelper()
        {
            //set all assmebly info
            UpdateAssemblyInfo();
        }

        private IEnumerable<Assembly> _allAssembly; 
 
        /// <summary>
        /// Return all the assembly in the application
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Assembly> GetAllAssemblyInApplication()
        {
            return _allAssembly;
        }

        /// <summary>
        /// Return all the assembly in the application
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Assembly> GetAllAssemblyInApplication(Func<Assembly, bool> expression)
        {
            return _allAssembly.Where(expression);
        }

        /// <summary>
        /// Return all the assembly in the application
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Assembly>> GetAllAssemblyInApplicationAsync()
        {
            return await Task.FromResult(_allAssembly);
        }

        /// <summary>
        /// Return all the assembly in the application
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Assembly>> GetAllAssemblyInApplicationAsync(Func<Assembly, bool> expression)
        {
            return await Task.FromResult(_allAssembly.Where(expression));
        }

        /// <summary>
        /// Scan all the assembly in the application
        /// </summary>
        /// <returns></returns>
        public bool UpdateAssemblyInfo()
        {
            var platform = Environment.OSVersion.Platform.ToString();
            var runtimeAssemblyNames = DependencyContext.Default.GetRuntimeAssemblyNames(platform);
            
            _allAssembly = runtimeAssemblyNames
                .Select(Assembly.Load); 
            return true;
        }

        public async Task<bool> UpdateAssemblyInfoAsync()
        {
            var platform = Environment.OSVersion.Platform.ToString();
            var runtimeAssemblyNames = DependencyContext.Default.GetRuntimeAssemblyNames(platform);

            _allAssembly = runtimeAssemblyNames
                .Select(Assembly.Load);
            return await Task.FromResult(true);
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Reflection;
//using System.Text;

//namespace SpaceX.Services
//{
//    public static class Helpers
//    {
//        private static TypeInfo FindCommand(string commandName)
//        {
//            Assembly currentAssembly = GetType().GetTypeInfo().Assembly;
//            var commandTypeInfo = currentAssembly.DefinedTypes
//                .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(IExportService)))
//                .Where(type => type.Name.ToLower() == (commandName.ToLower() + "exportservice"))
//                .SingleOrDefault();

//            if (commandTypeInfo == null)
//            {

//            }
//            return commandTypeInfo;
//        }
//    }
//}

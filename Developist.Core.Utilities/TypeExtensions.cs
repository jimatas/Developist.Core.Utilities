// Copyright (c) 2021 Jim Atas. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for details.

using System;
using System.Linq;

namespace Developist.Core.Utilities
{
    public static class TypeExtensions
    {
        public static bool IsConcrete(this Type type) => !(type.IsInterface || type.IsAbstract);

        public static bool ImplementsGenericInterface(this Type type, Type genericTypeDefinition)
            => GetImplementedGenericInterfaces(type, genericTypeDefinition).Any();

        public static Type[] GetImplementedGenericInterfaces(this Type type, Type genericTypeDefinition)
            => type.FindInterfaces((candidate, criteria) => candidate.IsGenericType && candidate.GetGenericTypeDefinition().Equals(criteria), genericTypeDefinition);

        public static bool DerivesFromGenericParent(this Type type, Type genericTypeDefinition)
        {
            if (type == typeof(object))
            {
                return false;
            }

            if (type.IsGenericType && type.GetGenericTypeDefinition() == genericTypeDefinition)
            {
                return true;
            }

            if (type.IsInterface)
            {
                return false;
            }

            return type.BaseType.DerivesFromGenericParent(genericTypeDefinition)
                || type.GetInterfaces().Any(iface => iface.DerivesFromGenericParent(genericTypeDefinition));
        }
    }
}

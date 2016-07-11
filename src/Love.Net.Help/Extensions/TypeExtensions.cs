﻿// Copyright (c) rigofunc (xuyingting). All rights reserved.

using System;
using System.Collections.Generic;
using System.Reflection;

namespace Love.Net.Help {
    /// <summary>
    /// The extension methods for <see cref="Type"/>.
    /// </summary>
    public static class TypeExtensions {
        public static bool IsNullableType(this Type type) {
            var typeInfo = type.GetTypeInfo();

            return !typeInfo.IsValueType
                   || (typeInfo.IsGenericType
                       && (typeInfo.GetGenericTypeDefinition() == typeof(Nullable<>)));
        }

        /// <summary>
        /// Gets the unwrap nullalble type if the the <paramref name="type"/> is nullable type or the type self.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type UnwrapNullableType(this Type type) => Nullable.GetUnderlyingType(type) ?? type;

        /// <summary>
        /// Determines the specified type is primitive type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsPrimitive(this Type type) => type.IsInteger() || type.IsNonIntegerPrimitive();

        /// <summary>
        /// Determines the specified type is integer type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsInteger(this Type type) {
            type = type.UnwrapNullableType();

            return (type == typeof(int))
                   || (type == typeof(long))
                   || (type == typeof(short))
                   || (type == typeof(byte))
                   || (type == typeof(uint))
                   || (type == typeof(ulong))
                   || (type == typeof(ushort))
                   || (type == typeof(sbyte))
                   || (type == typeof(char));
        }

        public static object GetDefaultValue(this Type type) {
            if (!type.GetTypeInfo().IsValueType) {
                return null;
            }

            // A bit of perf code to avoid calling Activator.CreateInstance for common types and
            // to avoid boxing on every call. This is about 50% faster than just calling CreateInstance
            // for all value types.
            object value;
            return _commonTypeDictionary.TryGetValue(type, out value)
                ? value
                : Activator.CreateInstance(type);
        }

        private static bool IsNonIntegerPrimitive(this Type type) {
            type = type.UnwrapNullableType();

            return (type == typeof(bool))
                   || (type == typeof(byte[]))
                   || (type == typeof(DateTime))
                   || (type == typeof(DateTimeOffset))
                   || (type == typeof(decimal))
                   || (type == typeof(double))
                   || (type == typeof(float))
                   || (type == typeof(Guid))
                   || (type == typeof(string))
                   || (type == typeof(TimeSpan))
                   || type.GetTypeInfo().IsEnum;
        }

        private static readonly Dictionary<Type, object> _commonTypeDictionary = new Dictionary<Type, object>
        {
            { typeof(int), default(int) },
            { typeof(Guid), default(Guid) },
            { typeof(DateTime), default(DateTime) },
            { typeof(DateTimeOffset), default(DateTimeOffset) },
            { typeof(long), default(long) },
            { typeof(bool), default(bool) },
            { typeof(double), default(double) },
            { typeof(short), default(short) },
            { typeof(float), default(float) },
            { typeof(byte), default(byte) },
            { typeof(char), default(char) },
            { typeof(uint), default(uint) },
            { typeof(ushort), default(ushort) },
            { typeof(ulong), default(ulong) },
            { typeof(sbyte), default(sbyte) }
        };
    }
}

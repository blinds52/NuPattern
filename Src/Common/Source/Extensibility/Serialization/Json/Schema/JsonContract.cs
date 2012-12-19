﻿using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace NuPattern.Extensibility.Serialization.Json
{
    internal enum JsonContractType
    {
        None,
        Object,
        Array,
        Primitive,
        String,
        Dictionary,
#if !(NET35 || NET20 || WINDOWS_PHONE)
        Dynamic,
#endif
#if !SILVERLIGHT && !PocketPC
        Serializable,
#endif
        Linq
    }

    internal enum ReadType
    {
        Read,
        ReadAsInt32,
        ReadAsDecimal,
        ReadAsBytes,
#if !NET20
        ReadAsDateTimeOffset
#endif
    }

    /// <summary>
    /// Contract details for a <see cref="Type"/> used by the <see cref="JsonSerializer"/>.
    /// </summary>
    public abstract class JsonContract
    {
        internal bool IsNullable;
        internal bool IsConvertable;
        internal Type NonNullableUnderlyingType;
        internal ReadType InternalReadType;
        internal JsonContractType ContractType;

        internal JsonContract(Type underlyingType)
        {
            Guard.NotNull(() => underlyingType, underlyingType);

            UnderlyingType = underlyingType;
            CreatedType = underlyingType;

            IsNullable = ReflectionUtils.IsNullable(underlyingType);

            NonNullableUnderlyingType = (IsNullable && ReflectionUtils.IsNullableType(underlyingType)) ? Nullable.GetUnderlyingType(underlyingType) : underlyingType;

            IsConvertable = typeof(IConvertible).IsAssignableFrom(NonNullableUnderlyingType);

            if (NonNullableUnderlyingType == typeof(byte[]))
            {
                InternalReadType = ReadType.ReadAsBytes;
            }
            else if (NonNullableUnderlyingType == typeof(int))
            {
                InternalReadType = ReadType.ReadAsInt32;
            }
            else if (NonNullableUnderlyingType == typeof(decimal))
            {
                InternalReadType = ReadType.ReadAsDecimal;
            }
#if !NET20
            else if (NonNullableUnderlyingType == typeof(DateTimeOffset))
            {
                InternalReadType = ReadType.ReadAsDateTimeOffset;
            }
#endif
            else
            {
                InternalReadType = ReadType.Read;
            }
        }

        /// <summary>
        /// Gets the underlying type for the contract.
        /// </summary>
        /// <value>The underlying type for the contract.</value>
        public Type UnderlyingType { get; private set; }

        /// <summary>
        /// Gets or sets the type created during deserialization.
        /// </summary>
        /// <value>The type created during deserialization.</value>
        public Type CreatedType { get; set; }

        //        /// <summary>
        //        /// Gets or sets whether this type contract is serialized as a reference.
        //        /// </summary>
        //        /// <value>Whether this type contract is serialized as a reference.</value>
        //        public bool? IsReference { get; set; }

        /// <summary>
        /// Gets or sets the default <see cref="JsonConverter" /> for this contract.
        /// </summary>
        /// <value>The converter.</value>
        public JsonConverter Converter { get; set; }

        // internally specified JsonConverter's to override default behavour
        // checked for after passed in converters and attribute specified converters
        internal JsonConverter InternalConverter { get; set; }

        //#if !PocketPC
        /// <summary>
        /// Gets or sets the method called immediately after deserialization of the object.
        /// </summary>
        /// <value>The method called immediately after deserialization of the object.</value>
        public MethodInfo OnDeserialized { get; set; }

        /// <summary>
        /// Gets or sets the method called during deserialization of the object.
        /// </summary>
        /// <value>The method called during deserialization of the object.</value>
        public MethodInfo OnDeserializing { get; set; }

        /// <summary>
        /// Gets or sets the method called after serialization of the object graph.
        /// </summary>
        /// <value>The method called after serialization of the object graph.</value>
        public MethodInfo OnSerialized { get; set; }

        /// <summary>
        /// Gets or sets the method called before serialization of the object.
        /// </summary>
        /// <value>The method called before serialization of the object.</value>
        public MethodInfo OnSerializing { get; set; }
        //#endif

        /// <summary>
        /// Gets or sets the default creator method used to create the object.
        /// </summary>
        /// <value>The default creator method used to create the object.</value>
        public Func<object> DefaultCreator { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [default creator non public].
        /// </summary>
        /// <value><c>true</c> if the default object creator is non-public; otherwise, <c>false</c>.</value>
        public bool DefaultCreatorNonPublic { get; set; }

        /// <summary>
        /// Gets or sets the method called when an error is thrown during the serialization of the object.
        /// </summary>
        /// <value>The method called when an error is thrown during the serialization of the object.</value>
        public MethodInfo OnError { get; set; }

        //        internal void InvokeOnSerializing(object o, StreamingContext context)
        //        {
        //#if !PocketPC
        //            if (OnSerializing != null)
        //                OnSerializing.Invoke(o, new object[] { context });
        //#endif
        //        }

        //        internal void InvokeOnSerialized(object o, StreamingContext context)
        //        {
        //#if !PocketPC
        //            if (OnSerialized != null)
        //                OnSerialized.Invoke(o, new object[] { context });
        //#endif
        //        }

        internal void InvokeOnDeserializing(object o, StreamingContext context)
        {
#if !PocketPC
            if (OnDeserializing != null)
                OnDeserializing.Invoke(o, new object[] { context });
#endif
        }

        internal void InvokeOnDeserialized(object o, StreamingContext context)
        {
#if !PocketPC
            if (OnDeserialized != null)
                OnDeserialized.Invoke(o, new object[] { context });
#endif
        }

        internal void InvokeOnError(object o, StreamingContext context, ErrorContext errorContext)
        {
            if (OnError != null)
                OnError.Invoke(o, new object[] { context, errorContext });
        }

    }
}
﻿using System;
using AutoCSer.Threading;
using System.Reflection;
using AutoCSer.Net.TcpServer;

namespace AutoCSer.Net.TcpOpenSimpleServer.Emit
{
    /// <summary>
    /// 输出参数泛型类型元数据
    /// </summary>
    internal abstract partial class ParameterGenericType : AutoCSer.Net.TcpSimpleServer.Emit.ParameterGenericType
    {
        /// <summary>
        /// TCP 开放服务客户端
        /// </summary>
        internal static readonly TcpOpenSimpleServer.Client Client = new Client();
        /// <summary>
        /// TCP 开放服务端套接字
        /// </summary>
        internal static readonly ServerSocket ServerSocket = new ServerSocket();

        /// <summary>
        /// 泛型类型元数据缓存
        /// </summary>
        private static readonly AutoCSer.Threading.LockLastDictionary<Type, ParameterGenericType> cache = new LockLastDictionary<Type, ParameterGenericType>();
        /// <summary>
        /// 创建泛型类型元数据
        /// </summary>
        /// <typeparam name="parameterType"></typeparam>
        /// <returns></returns>
        [AutoCSer.IOS.Preserve(Conditional = true)]
        private static ParameterGenericType create<parameterType>()
        where parameterType : struct
        {
            return new ParameterGenericType<parameterType>();
        }
        /// <summary>
        /// 创建泛型类型元数据 函数信息
        /// </summary>
        private static readonly MethodInfo createMethod = typeof(ParameterGenericType).GetMethod("create", BindingFlags.Static | BindingFlags.NonPublic);
        /// <summary>
        /// 获取泛型类型元数据
        /// </summary>
        /// <param name="outputParameterType"></param>
        /// <returns></returns>
        public static ParameterGenericType Get(Type outputParameterType)
        {
            ParameterGenericType value;
            if (!cache.TryGetValue(outputParameterType, out value))
            {
                try
                {
                    value = new UnionType { Value = createMethod.MakeGenericMethod(outputParameterType).Invoke(null, null) }.ParameterGenericType;
                    cache.Set(outputParameterType, value);
                }
                finally { cache.Exit(); }
            }
            return value;
        }
    }
    /// <summary>
    /// 泛型类型元数据
    /// </summary>
    /// <typeparam name="parameterType">泛型类型</typeparam>
    internal sealed partial class ParameterGenericType<parameterType> : ParameterGenericType
        where parameterType : struct
    {
        /// <summary>
        /// TCP调用
        /// </summary>
        internal override MethodInfo ClientCallMethod
        {
            get { return ((AutoCSer.Net.TcpInternalSimpleServer.Emit.ParameterGenericType<parameterType>.Call)Client.Call<parameterType>).Method; }
        }
        /// <summary>
        /// TCP调用并返回参数值
        /// </summary>
        internal override MethodInfo ClientGetMethod
        {
            get { return ((AutoCSer.Net.TcpInternalSimpleServer.Emit.ParameterGenericType<parameterType>.Call)Client.Get<parameterType>).Method; }
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        internal override MethodInfo ServerSocketSendMethod
        {
            get { return ((AutoCSer.Net.TcpInternalSimpleServer.Emit.ParameterGenericType<parameterType>.Send)ServerSocket.Send<parameterType>).Method; }
        }
    }
}

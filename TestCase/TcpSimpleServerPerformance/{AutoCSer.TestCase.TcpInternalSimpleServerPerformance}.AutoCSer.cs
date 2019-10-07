//本文件由程序自动生成,请不要自行修改
using System;
using AutoCSer;

#if NoAutoCSer
#else
#pragma warning disable
namespace AutoCSer.TestCase.TcpInternalSimpleServerPerformance
{
        public partial class InternalSimpleServer
        {
            /// <summary>
            /// TcpInternalSimpleServerPerformance TCP服务
            /// </summary>
            public sealed class TcpInternalSimpleServer : AutoCSer.Net.TcpInternalSimpleServer.Server
            {
                public readonly AutoCSer.TestCase.TcpInternalSimpleServerPerformance.InternalSimpleServer Value;
                /// <summary>
                /// TcpInternalSimpleServerPerformance TCP调用服务端
                /// </summary>
                /// <param name="attribute">TCP 调用服务器端配置信息</param>
                /// <param name="verify">套接字验证委托</param>
                /// <param name="value">TCP 服务目标对象</param>
                /// <param name="log">日志接口</param>
                public TcpInternalSimpleServer(AutoCSer.Net.TcpInternalSimpleServer.ServerAttribute attribute = null, Func<System.Net.Sockets.Socket, bool> verify = null, AutoCSer.TestCase.TcpInternalSimpleServerPerformance.InternalSimpleServer value = null, AutoCSer.Log.ILog log = null)
                    : base(attribute ?? (attribute = AutoCSer.Net.TcpInternalSimpleServer.ServerAttribute.GetConfig("TcpInternalSimpleServerPerformance", typeof(AutoCSer.TestCase.TcpInternalSimpleServerPerformance.InternalSimpleServer))), verify, log, false)
                {
                    Value = value ?? new AutoCSer.TestCase.TcpInternalSimpleServerPerformance.InternalSimpleServer();
                    setCommandData(2);
                    setCommand(0);
                    setCommand(1);
                    if (attribute.IsAutoServer) Start();
                }
                /// <summary>
                /// 命令处理
                /// </summary>
                /// <param name="index">命令序号</param>
                /// <param name="socket">TCP 内部服务套接字数据发送</param>
                /// <param name="data">命令数据</param>
                /// <returns>是否成功</returns>
                public override bool DoCommand(int index, AutoCSer.Net.TcpInternalSimpleServer.ServerSocket socket, ref SubArray<byte> data)
                {
                    AutoCSer.Net.TcpServer.ReturnType returnType;
                    switch (index - 128)
                    {
                        case 0:
                            returnType = AutoCSer.Net.TcpServer.ReturnType.Unknown;
                            try
                            {
                                _p1 inputParameter = new _p1();
                                if (socket.DeSerialize(ref data, ref inputParameter, true))
                                {
                                    _p2 outputParameter = new _p2();
                                    
                                    Value.addAsynchronous(inputParameter.p0, inputParameter.p1, socket.GetCallback<_p2, int>(_c0, ref outputParameter));
                                    return true;
                                }
                                returnType = AutoCSer.Net.TcpServer.ReturnType.ServerDeSerializeError;
                            }
                            catch (Exception error)
                            {
                                returnType = AutoCSer.Net.TcpServer.ReturnType.ServerException;
                                socket.Log(error);
                            }
                            return socket.SendOutput(returnType);
                        case 1:
                            returnType = AutoCSer.Net.TcpServer.ReturnType.Unknown;
                            try
                            {
                                _p1 inputParameter = new _p1();
                                if (socket.DeSerialize(ref data, ref inputParameter, true))
                                {
                                    _p2 _outputParameter_ = new _p2();
                                    
                                    int Return;
                                    
                                    Return = Value.addSynchronous(inputParameter.p0, inputParameter.p1);
                                    _outputParameter_.Return = Return;
                                    return socket.Send(_c1, ref _outputParameter_);
                                }
                                returnType = AutoCSer.Net.TcpServer.ReturnType.ServerDeSerializeError;
                            }
                            catch (Exception error)
                            {
                                returnType = AutoCSer.Net.TcpServer.ReturnType.ServerException;
                                socket.Log(error);
                            }
                            return socket.SendOutput(returnType);
                        default: return false;
                    }
                }
                private static readonly AutoCSer.Net.TcpSimpleServer.OutputInfo _c0 = new AutoCSer.Net.TcpSimpleServer.OutputInfo { OutputParameterIndex = 2, IsSimpleSerializeOutputParamter = true };
                private static readonly AutoCSer.Net.TcpSimpleServer.OutputInfo _c1 = new AutoCSer.Net.TcpSimpleServer.OutputInfo { OutputParameterIndex = 2, IsSimpleSerializeOutputParamter = true };
                static TcpInternalSimpleServer()
                {
                    CompileSerialize(new System.Type[] { typeof(_p1), null }
                        , new System.Type[] { typeof(_p2), null }
                        , new System.Type[] { null }
                        , new System.Type[] { null }
                        , new System.Type[] { null }
                        , new System.Type[] { null });
                }

                [AutoCSer.BinarySerialize.Serialize(IsMemberMap = false)]
                [AutoCSer.Metadata.BoxSerialize]
                [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Auto)]
                internal struct _p1
                {
                    public int p0;
                    public int p1;
                }
                [AutoCSer.BinarySerialize.Serialize(IsMemberMap = false)]
                [AutoCSer.Metadata.BoxSerialize]
                [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Auto)]
                internal struct _p2
#if NOJIT
                     : AutoCSer.Net.IReturnParameter
#else
                     : AutoCSer.Net.IReturnParameter<int>
#endif
                {
                    [AutoCSer.Json.IgnoreMember]
                    public int Ret;
                    [AutoCSer.IOS.Preserve(Conditional = true)]
                    public int Return
                    {
                        get { return Ret; }
                        set { Ret = value; }
                    }
#if NOJIT
                    [AutoCSer.Metadata.Ignore]
                    public object ReturnObject
                    {
                        get { return Ret; }
                        set { Ret = (int)value; }
                    }
#endif
                }
            }
            /// <summary>
            /// TCP客户端
            /// </summary>
            public partial class TcpInternalSimpleClient : AutoCSer.Net.TcpInternalSimpleServer.MethodClient<TcpInternalSimpleClient>
            {
                /// <summary>
                /// TCP调用客户端
                /// </summary>
                /// <param name="attribute">TCP 调用服务器端配置信息</param>
                /// <param name="log">日志接口</param>
                public TcpInternalSimpleClient(AutoCSer.Net.TcpInternalSimpleServer.ServerAttribute attribute = null, AutoCSer.Log.ILog log = null)
                {
                    if (attribute == null)
                    {
                        attribute = AutoCSer.Net.TcpInternalSimpleServer.ServerAttribute.GetConfig("TcpInternalSimpleServerPerformance", typeof(AutoCSer.TestCase.TcpInternalSimpleServerPerformance.InternalSimpleServer));
                    }
                    _TcpClient_ = new AutoCSer.Net.TcpInternalSimpleServer.Client<TcpInternalSimpleClient>(this, attribute, log);
                    if (attribute.IsAuto) _TcpClient_.TryCreateSocket();
                }

                private static readonly AutoCSer.Net.TcpServer.CommandInfoBase _c0 = new AutoCSer.Net.TcpServer.CommandInfoBase { Command = 0 + 128, InputParameterIndex = 1, IsSimpleSerializeInputParamter = true, IsSimpleSerializeOutputParamter = true };

                /// <summary>
                /// 异步计算测试
                /// </summary>
                public 
                AutoCSer.Net.TcpServer.ReturnValue<int> addAsynchronous(int left, int right)
                {
                    if (_isDisposed_ == 0)
                    {
                        TcpInternalSimpleServer._p1 _inputParameter_ = new TcpInternalSimpleServer._p1
                        {
                            
                            p0 = left,
                            
                            p1 = right,
                        };
                        TcpInternalSimpleServer._p2 _outputParameter_ = new TcpInternalSimpleServer._p2
                        {
                        };
                        AutoCSer.Net.TcpServer.ReturnType _returnType_ = _TcpClient_.Get<TcpInternalSimpleServer._p1, TcpInternalSimpleServer._p2>(_c0, ref _inputParameter_, ref _outputParameter_);
                        return new AutoCSer.Net.TcpServer.ReturnValue<int> { Type = _returnType_, Value = _outputParameter_.Return };
                    }
                    return new AutoCSer.Net.TcpServer.ReturnValue<int> { Type = AutoCSer.Net.TcpServer.ReturnType.ClientException };
                }

                private static readonly AutoCSer.Net.TcpServer.CommandInfoBase _c1 = new AutoCSer.Net.TcpServer.CommandInfoBase { Command = 1 + 128, InputParameterIndex = 1, IsSimpleSerializeInputParamter = true, IsSimpleSerializeOutputParamter = true };

                /// <summary>
                /// 简单计算测试
                /// </summary>
                public 
                AutoCSer.Net.TcpServer.ReturnValue<int> addSynchronous(int left, int right)
                {
                    if (_isDisposed_ == 0)
                    {
                        TcpInternalSimpleServer._p1 _inputParameter_ = new TcpInternalSimpleServer._p1
                        {
                            
                            p0 = left,
                            
                            p1 = right,
                        };
                        TcpInternalSimpleServer._p2 _outputParameter_ = new TcpInternalSimpleServer._p2
                        {
                        };
                        AutoCSer.Net.TcpServer.ReturnType _returnType_ = _TcpClient_.Get<TcpInternalSimpleServer._p1, TcpInternalSimpleServer._p2>(_c1, ref _inputParameter_, ref _outputParameter_);
                        return new AutoCSer.Net.TcpServer.ReturnValue<int> { Type = _returnType_, Value = _outputParameter_.Return };
                    }
                    return new AutoCSer.Net.TcpServer.ReturnValue<int> { Type = AutoCSer.Net.TcpServer.ReturnType.ClientException };
                }

                static TcpInternalSimpleClient()
                {
                    _compileSerialize_(new System.Type[] { typeof(TcpInternalSimpleServer._p1), null }
                        , new System.Type[] { typeof(TcpInternalSimpleServer._p2), null }
                        , new System.Type[] { null }
                        , new System.Type[] { null }
                        , new System.Type[] { null }
                        , new System.Type[] { null });
                }
            }
        }
}
#endif
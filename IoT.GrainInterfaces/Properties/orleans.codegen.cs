#if !EXCLUDE_CODEGEN
#pragma warning disable 162
#pragma warning disable 219
#pragma warning disable 414
#pragma warning disable 649
#pragma warning disable 693
#pragma warning disable 1591
#pragma warning disable 1998
[assembly: global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.1.3.0")]
[assembly: global::Orleans.CodeGeneration.OrleansCodeGenerationTargetAttribute("IoT.GrainInterfaces, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")]
namespace IoT.GrainInterfaces
{
    using global::Orleans.Async;
    using global::Orleans;

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.1.3.0"), global::System.SerializableAttribute, global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute, global::Orleans.CodeGeneration.GrainReferenceAttribute(typeof (global::IoT.GrainInterfaces.IDeviceGrain))]
    internal class OrleansCodeGenDeviceGrainReference : global::Orleans.Runtime.GrainReference, global::IoT.GrainInterfaces.IDeviceGrain
    {
        protected @OrleansCodeGenDeviceGrainReference(global::Orleans.Runtime.GrainReference @other): base (@other)
        {
        }

        protected @OrleansCodeGenDeviceGrainReference(global::System.Runtime.Serialization.SerializationInfo @info, global::System.Runtime.Serialization.StreamingContext @context): base (@info, @context)
        {
        }

        protected override global::System.Int32 InterfaceId
        {
            get
            {
                return -1248350959;
            }
        }

        public override global::System.String InterfaceName
        {
            get
            {
                return "global::IoT.GrainInterfaces.IDeviceGrain";
            }
        }

        public override global::System.Boolean @IsCompatible(global::System.Int32 @interfaceId)
        {
            return @interfaceId == -1248350959;
        }

        protected override global::System.String @GetMethodName(global::System.Int32 @interfaceId, global::System.Int32 @methodId)
        {
            switch (@interfaceId)
            {
                case -1248350959:
                    switch (@methodId)
                    {
                        case -251329296:
                            return "SetTemperatureAsync";
                        case 254451615:
                            return "GetTemperatureAsync";
                        default:
                            throw new global::System.NotImplementedException("interfaceId=" + -1248350959 + ",methodId=" + @methodId);
                    }

                default:
                    throw new global::System.NotImplementedException("interfaceId=" + @interfaceId);
            }
        }

        public global::System.Threading.Tasks.Task @SetTemperatureAsync(global::System.Double @value)
        {
            return base.@InvokeMethodAsync<global::System.Object>(-251329296, new global::System.Object[]{@value});
        }

        public global::System.Threading.Tasks.Task<global::System.Double> @GetTemperatureAsync()
        {
            return base.@InvokeMethodAsync<global::System.Double>(254451615, null);
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.1.3.0"), global::Orleans.CodeGeneration.MethodInvokerAttribute("global::IoT.GrainInterfaces.IDeviceGrain", -1248350959, typeof (global::IoT.GrainInterfaces.IDeviceGrain)), global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
    internal class OrleansCodeGenDeviceGrainMethodInvoker : global::Orleans.CodeGeneration.IGrainMethodInvoker
    {
        public global::System.Threading.Tasks.Task<global::System.Object> @Invoke(global::Orleans.Runtime.IAddressable @grain, global::System.Int32 @interfaceId, global::System.Int32 @methodId, global::System.Object[] @arguments)
        {
            try
            {
                if (@grain == null)
                    throw new global::System.ArgumentNullException("grain");
                switch (@interfaceId)
                {
                    case -1248350959:
                        switch (@methodId)
                        {
                            case -251329296:
                                return ((global::IoT.GrainInterfaces.IDeviceGrain)@grain).@SetTemperatureAsync((global::System.Double)@arguments[0]).@Box();
                            case 254451615:
                                return ((global::IoT.GrainInterfaces.IDeviceGrain)@grain).@GetTemperatureAsync().@Box();
                            default:
                                throw new global::System.NotImplementedException("interfaceId=" + -1248350959 + ",methodId=" + @methodId);
                        }

                    default:
                        throw new global::System.NotImplementedException("interfaceId=" + @interfaceId);
                }
            }
            catch (global::System.Exception exception)
            {
                return global::Orleans.Async.TaskUtility.@Faulted(exception);
            }
        }

        public global::System.Int32 InterfaceId
        {
            get
            {
                return -1248350959;
            }
        }
    }
}
#pragma warning restore 162
#pragma warning restore 219
#pragma warning restore 414
#pragma warning restore 649
#pragma warning restore 693
#pragma warning restore 1591
#pragma warning restore 1998
#endif

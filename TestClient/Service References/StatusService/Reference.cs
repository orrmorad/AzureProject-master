﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestClient.StatusService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="StatusService.IUserStateService", CallbackContract=typeof(TestClient.StatusService.IUserStateServiceCallback))]
    public interface IUserStateService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserStateService/OpenSession", ReplyAction="http://tempuri.org/IUserStateService/OpenSessionResponse")]
        void OpenSession();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserStateService/OpenSession", ReplyAction="http://tempuri.org/IUserStateService/OpenSessionResponse")]
        System.Threading.Tasks.Task OpenSessionAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserStateServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserStateService/NewUser", ReplyAction="http://tempuri.org/IUserStateService/NewUserResponse")]
        void NewUser(Model.User user);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserStateServiceChannel : TestClient.StatusService.IUserStateService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserStateServiceClient : System.ServiceModel.DuplexClientBase<TestClient.StatusService.IUserStateService>, TestClient.StatusService.IUserStateService {
        
        public UserStateServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public UserStateServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public UserStateServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public UserStateServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public UserStateServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void OpenSession() {
            base.Channel.OpenSession();
        }
        
        public System.Threading.Tasks.Task OpenSessionAsync() {
            return base.Channel.OpenSessionAsync();
        }
    }
}

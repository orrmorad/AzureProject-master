﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CheckersClient.UserStatusService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UserStatusService.IUserStateService")]
    public interface IUserStateService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserStateService/GetOnlineUsers", ReplyAction="http://tempuri.org/IUserStateService/GetOnlineUsersResponse")]
        void GetOnlineUsers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserStateService/GetOnlineUsers", ReplyAction="http://tempuri.org/IUserStateService/GetOnlineUsersResponse")]
        System.Threading.Tasks.Task GetOnlineUsersAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserStateServiceChannel : CheckersClient.UserStatusService.IUserStateService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserStateServiceClient : System.ServiceModel.ClientBase<CheckersClient.UserStatusService.IUserStateService>, CheckersClient.UserStatusService.IUserStateService {
        
        public UserStateServiceClient() {
        }
        
        public UserStateServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserStateServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserStateServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserStateServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void GetOnlineUsers() {
            base.Channel.GetOnlineUsers();
        }
        
        public System.Threading.Tasks.Task GetOnlineUsersAsync() {
            return base.Channel.GetOnlineUsersAsync();
        }
    }
}

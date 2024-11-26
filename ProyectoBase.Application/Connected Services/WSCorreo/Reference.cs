﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoBase.Application.WSCorreo {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.asae.com.mx", ConfigurationName="WSCorreo.CorreoSoap")]
    public interface CorreoSoap {
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de elemento host del espacio de nombres http://www.asae.com.mx no está marcado para aceptar valores nil.
        [System.ServiceModel.OperationContractAttribute(Action="http://www.asae.com.mx/CorreoMetPrivado", ReplyAction="*")]
        ProyectoBase.Application.WSCorreo.CorreoMetPrivadoResponse CorreoMetPrivado(ProyectoBase.Application.WSCorreo.CorreoMetPrivadoRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.asae.com.mx/CorreoMetPrivado", ReplyAction="*")]
        System.Threading.Tasks.Task<ProyectoBase.Application.WSCorreo.CorreoMetPrivadoResponse> CorreoMetPrivadoAsync(ProyectoBase.Application.WSCorreo.CorreoMetPrivadoRequest request);
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de elemento host del espacio de nombres http://www.asae.com.mx no está marcado para aceptar valores nil.
        [System.ServiceModel.OperationContractAttribute(Action="http://www.asae.com.mx/CorreoAsaeTickets", ReplyAction="*")]
        ProyectoBase.Application.WSCorreo.CorreoAsaeTicketsResponse CorreoAsaeTickets(ProyectoBase.Application.WSCorreo.CorreoAsaeTicketsRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.asae.com.mx/CorreoAsaeTickets", ReplyAction="*")]
        System.Threading.Tasks.Task<ProyectoBase.Application.WSCorreo.CorreoAsaeTicketsResponse> CorreoAsaeTicketsAsync(ProyectoBase.Application.WSCorreo.CorreoAsaeTicketsRequest request);
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de elemento host del espacio de nombres http://www.asae.com.mx no está marcado para aceptar valores nil.
        [System.ServiceModel.OperationContractAttribute(Action="http://www.asae.com.mx/CorreoAsaeCRM_AgendaEvento", ReplyAction="*")]
        ProyectoBase.Application.WSCorreo.CorreoAsaeCRM_AgendaEventoResponse CorreoAsaeCRM_AgendaEvento(ProyectoBase.Application.WSCorreo.CorreoAsaeCRM_AgendaEventoRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.asae.com.mx/CorreoAsaeCRM_AgendaEvento", ReplyAction="*")]
        System.Threading.Tasks.Task<ProyectoBase.Application.WSCorreo.CorreoAsaeCRM_AgendaEventoResponse> CorreoAsaeCRM_AgendaEventoAsync(ProyectoBase.Application.WSCorreo.CorreoAsaeCRM_AgendaEventoRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CorreoMetPrivadoRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CorreoMetPrivado", Namespace="http://www.asae.com.mx", Order=0)]
        public ProyectoBase.Application.WSCorreo.CorreoMetPrivadoRequestBody Body;
        
        public CorreoMetPrivadoRequest() {
        }
        
        public CorreoMetPrivadoRequest(ProyectoBase.Application.WSCorreo.CorreoMetPrivadoRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.asae.com.mx")]
    public partial class CorreoMetPrivadoRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string host;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public int puerto;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string usuario;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string contra;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string Email;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string from;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string Subject;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public string body;
        
        public CorreoMetPrivadoRequestBody() {
        }
        
        public CorreoMetPrivadoRequestBody(string host, int puerto, string usuario, string contra, string Email, string from, string Subject, string body) {
            this.host = host;
            this.puerto = puerto;
            this.usuario = usuario;
            this.contra = contra;
            this.Email = Email;
            this.from = from;
            this.Subject = Subject;
            this.body = body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CorreoMetPrivadoResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CorreoMetPrivadoResponse", Namespace="http://www.asae.com.mx", Order=0)]
        public ProyectoBase.Application.WSCorreo.CorreoMetPrivadoResponseBody Body;
        
        public CorreoMetPrivadoResponse() {
        }
        
        public CorreoMetPrivadoResponse(ProyectoBase.Application.WSCorreo.CorreoMetPrivadoResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.asae.com.mx")]
    public partial class CorreoMetPrivadoResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string CorreoMetPrivadoResult;
        
        public CorreoMetPrivadoResponseBody() {
        }
        
        public CorreoMetPrivadoResponseBody(string CorreoMetPrivadoResult) {
            this.CorreoMetPrivadoResult = CorreoMetPrivadoResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CorreoAsaeTicketsRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CorreoAsaeTickets", Namespace="http://www.asae.com.mx", Order=0)]
        public ProyectoBase.Application.WSCorreo.CorreoAsaeTicketsRequestBody Body;
        
        public CorreoAsaeTicketsRequest() {
        }
        
        public CorreoAsaeTicketsRequest(ProyectoBase.Application.WSCorreo.CorreoAsaeTicketsRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.asae.com.mx")]
    public partial class CorreoAsaeTicketsRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string host;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public int puerto;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string usuario;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string contra;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string Email;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string EmailCopia;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string from;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public string Subject;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=8)]
        public string body;
        
        public CorreoAsaeTicketsRequestBody() {
        }
        
        public CorreoAsaeTicketsRequestBody(string host, int puerto, string usuario, string contra, string Email, string EmailCopia, string from, string Subject, string body) {
            this.host = host;
            this.puerto = puerto;
            this.usuario = usuario;
            this.contra = contra;
            this.Email = Email;
            this.EmailCopia = EmailCopia;
            this.from = from;
            this.Subject = Subject;
            this.body = body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CorreoAsaeTicketsResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CorreoAsaeTicketsResponse", Namespace="http://www.asae.com.mx", Order=0)]
        public ProyectoBase.Application.WSCorreo.CorreoAsaeTicketsResponseBody Body;
        
        public CorreoAsaeTicketsResponse() {
        }
        
        public CorreoAsaeTicketsResponse(ProyectoBase.Application.WSCorreo.CorreoAsaeTicketsResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.asae.com.mx")]
    public partial class CorreoAsaeTicketsResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string CorreoAsaeTicketsResult;
        
        public CorreoAsaeTicketsResponseBody() {
        }
        
        public CorreoAsaeTicketsResponseBody(string CorreoAsaeTicketsResult) {
            this.CorreoAsaeTicketsResult = CorreoAsaeTicketsResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CorreoAsaeCRM_AgendaEventoRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CorreoAsaeCRM_AgendaEvento", Namespace="http://www.asae.com.mx", Order=0)]
        public ProyectoBase.Application.WSCorreo.CorreoAsaeCRM_AgendaEventoRequestBody Body;
        
        public CorreoAsaeCRM_AgendaEventoRequest() {
        }
        
        public CorreoAsaeCRM_AgendaEventoRequest(ProyectoBase.Application.WSCorreo.CorreoAsaeCRM_AgendaEventoRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.asae.com.mx")]
    public partial class CorreoAsaeCRM_AgendaEventoRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string host;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public int puerto;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string usuario;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string contra;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string Email;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string EmailCopia;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string from;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public string Subject;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=8)]
        public string body;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=9)]
        public string archivoNombre;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=10)]
        public string EventoTitulo;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=11)]
        public System.DateTime EventoFechaI;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=12)]
        public System.DateTime EventoFechaF;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=13)]
        public string EventoOrganizaNombre;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=14)]
        public string EventoOrganizaMail;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=15)]
        public string EventoAsunto;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=16)]
        public string EventoDescripcion;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=17)]
        public string EventoUbicacion;
        
        public CorreoAsaeCRM_AgendaEventoRequestBody() {
        }
        
        public CorreoAsaeCRM_AgendaEventoRequestBody(
                    string host, 
                    int puerto, 
                    string usuario, 
                    string contra, 
                    string Email, 
                    string EmailCopia, 
                    string from, 
                    string Subject, 
                    string body, 
                    string archivoNombre, 
                    string EventoTitulo, 
                    System.DateTime EventoFechaI, 
                    System.DateTime EventoFechaF, 
                    string EventoOrganizaNombre, 
                    string EventoOrganizaMail, 
                    string EventoAsunto, 
                    string EventoDescripcion, 
                    string EventoUbicacion) {
            this.host = host;
            this.puerto = puerto;
            this.usuario = usuario;
            this.contra = contra;
            this.Email = Email;
            this.EmailCopia = EmailCopia;
            this.from = from;
            this.Subject = Subject;
            this.body = body;
            this.archivoNombre = archivoNombre;
            this.EventoTitulo = EventoTitulo;
            this.EventoFechaI = EventoFechaI;
            this.EventoFechaF = EventoFechaF;
            this.EventoOrganizaNombre = EventoOrganizaNombre;
            this.EventoOrganizaMail = EventoOrganizaMail;
            this.EventoAsunto = EventoAsunto;
            this.EventoDescripcion = EventoDescripcion;
            this.EventoUbicacion = EventoUbicacion;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CorreoAsaeCRM_AgendaEventoResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CorreoAsaeCRM_AgendaEventoResponse", Namespace="http://www.asae.com.mx", Order=0)]
        public ProyectoBase.Application.WSCorreo.CorreoAsaeCRM_AgendaEventoResponseBody Body;
        
        public CorreoAsaeCRM_AgendaEventoResponse() {
        }
        
        public CorreoAsaeCRM_AgendaEventoResponse(ProyectoBase.Application.WSCorreo.CorreoAsaeCRM_AgendaEventoResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.asae.com.mx")]
    public partial class CorreoAsaeCRM_AgendaEventoResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string CorreoAsaeCRM_AgendaEventoResult;
        
        public CorreoAsaeCRM_AgendaEventoResponseBody() {
        }
        
        public CorreoAsaeCRM_AgendaEventoResponseBody(string CorreoAsaeCRM_AgendaEventoResult) {
            this.CorreoAsaeCRM_AgendaEventoResult = CorreoAsaeCRM_AgendaEventoResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface CorreoSoapChannel : ProyectoBase.Application.WSCorreo.CorreoSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CorreoSoapClient : System.ServiceModel.ClientBase<ProyectoBase.Application.WSCorreo.CorreoSoap>, ProyectoBase.Application.WSCorreo.CorreoSoap {
        
        public CorreoSoapClient() {
        }
        
        public CorreoSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CorreoSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CorreoSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CorreoSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ProyectoBase.Application.WSCorreo.CorreoMetPrivadoResponse ProyectoBase.Application.WSCorreo.CorreoSoap.CorreoMetPrivado(ProyectoBase.Application.WSCorreo.CorreoMetPrivadoRequest request) {
            return base.Channel.CorreoMetPrivado(request);
        }
        
        public string CorreoMetPrivado(string host, int puerto, string usuario, string contra, string Email, string from, string Subject, string body) {
            ProyectoBase.Application.WSCorreo.CorreoMetPrivadoRequest inValue = new ProyectoBase.Application.WSCorreo.CorreoMetPrivadoRequest();
            inValue.Body = new ProyectoBase.Application.WSCorreo.CorreoMetPrivadoRequestBody();
            inValue.Body.host = host;
            inValue.Body.puerto = puerto;
            inValue.Body.usuario = usuario;
            inValue.Body.contra = contra;
            inValue.Body.Email = Email;
            inValue.Body.from = from;
            inValue.Body.Subject = Subject;
            inValue.Body.body = body;
            ProyectoBase.Application.WSCorreo.CorreoMetPrivadoResponse retVal = ((ProyectoBase.Application.WSCorreo.CorreoSoap)(this)).CorreoMetPrivado(inValue);
            return retVal.Body.CorreoMetPrivadoResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ProyectoBase.Application.WSCorreo.CorreoMetPrivadoResponse> ProyectoBase.Application.WSCorreo.CorreoSoap.CorreoMetPrivadoAsync(ProyectoBase.Application.WSCorreo.CorreoMetPrivadoRequest request) {
            return base.Channel.CorreoMetPrivadoAsync(request);
        }
        
        public System.Threading.Tasks.Task<ProyectoBase.Application.WSCorreo.CorreoMetPrivadoResponse> CorreoMetPrivadoAsync(string host, int puerto, string usuario, string contra, string Email, string from, string Subject, string body) {
            ProyectoBase.Application.WSCorreo.CorreoMetPrivadoRequest inValue = new ProyectoBase.Application.WSCorreo.CorreoMetPrivadoRequest();
            inValue.Body = new ProyectoBase.Application.WSCorreo.CorreoMetPrivadoRequestBody();
            inValue.Body.host = host;
            inValue.Body.puerto = puerto;
            inValue.Body.usuario = usuario;
            inValue.Body.contra = contra;
            inValue.Body.Email = Email;
            inValue.Body.from = from;
            inValue.Body.Subject = Subject;
            inValue.Body.body = body;
            return ((ProyectoBase.Application.WSCorreo.CorreoSoap)(this)).CorreoMetPrivadoAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ProyectoBase.Application.WSCorreo.CorreoAsaeTicketsResponse ProyectoBase.Application.WSCorreo.CorreoSoap.CorreoAsaeTickets(ProyectoBase.Application.WSCorreo.CorreoAsaeTicketsRequest request) {
            return base.Channel.CorreoAsaeTickets(request);
        }
        
        public string CorreoAsaeTickets(string host, int puerto, string usuario, string contra, string Email, string EmailCopia, string from, string Subject, string body) {
            ProyectoBase.Application.WSCorreo.CorreoAsaeTicketsRequest inValue = new ProyectoBase.Application.WSCorreo.CorreoAsaeTicketsRequest();
            inValue.Body = new ProyectoBase.Application.WSCorreo.CorreoAsaeTicketsRequestBody();
            inValue.Body.host = host;
            inValue.Body.puerto = puerto;
            inValue.Body.usuario = usuario;
            inValue.Body.contra = contra;
            inValue.Body.Email = Email;
            inValue.Body.EmailCopia = EmailCopia;
            inValue.Body.from = from;
            inValue.Body.Subject = Subject;
            inValue.Body.body = body;
            ProyectoBase.Application.WSCorreo.CorreoAsaeTicketsResponse retVal = ((ProyectoBase.Application.WSCorreo.CorreoSoap)(this)).CorreoAsaeTickets(inValue);
            return retVal.Body.CorreoAsaeTicketsResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ProyectoBase.Application.WSCorreo.CorreoAsaeTicketsResponse> ProyectoBase.Application.WSCorreo.CorreoSoap.CorreoAsaeTicketsAsync(ProyectoBase.Application.WSCorreo.CorreoAsaeTicketsRequest request) {
            return base.Channel.CorreoAsaeTicketsAsync(request);
        }
        
        public System.Threading.Tasks.Task<ProyectoBase.Application.WSCorreo.CorreoAsaeTicketsResponse> CorreoAsaeTicketsAsync(string host, int puerto, string usuario, string contra, string Email, string EmailCopia, string from, string Subject, string body) {
            ProyectoBase.Application.WSCorreo.CorreoAsaeTicketsRequest inValue = new ProyectoBase.Application.WSCorreo.CorreoAsaeTicketsRequest();
            inValue.Body = new ProyectoBase.Application.WSCorreo.CorreoAsaeTicketsRequestBody();
            inValue.Body.host = host;
            inValue.Body.puerto = puerto;
            inValue.Body.usuario = usuario;
            inValue.Body.contra = contra;
            inValue.Body.Email = Email;
            inValue.Body.EmailCopia = EmailCopia;
            inValue.Body.from = from;
            inValue.Body.Subject = Subject;
            inValue.Body.body = body;
            return ((ProyectoBase.Application.WSCorreo.CorreoSoap)(this)).CorreoAsaeTicketsAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ProyectoBase.Application.WSCorreo.CorreoAsaeCRM_AgendaEventoResponse ProyectoBase.Application.WSCorreo.CorreoSoap.CorreoAsaeCRM_AgendaEvento(ProyectoBase.Application.WSCorreo.CorreoAsaeCRM_AgendaEventoRequest request) {
            return base.Channel.CorreoAsaeCRM_AgendaEvento(request);
        }
        
        public string CorreoAsaeCRM_AgendaEvento(
                    string host, 
                    int puerto, 
                    string usuario, 
                    string contra, 
                    string Email, 
                    string EmailCopia, 
                    string from, 
                    string Subject, 
                    string body, 
                    string archivoNombre, 
                    string EventoTitulo, 
                    System.DateTime EventoFechaI, 
                    System.DateTime EventoFechaF, 
                    string EventoOrganizaNombre, 
                    string EventoOrganizaMail, 
                    string EventoAsunto, 
                    string EventoDescripcion, 
                    string EventoUbicacion) {
            ProyectoBase.Application.WSCorreo.CorreoAsaeCRM_AgendaEventoRequest inValue = new ProyectoBase.Application.WSCorreo.CorreoAsaeCRM_AgendaEventoRequest();
            inValue.Body = new ProyectoBase.Application.WSCorreo.CorreoAsaeCRM_AgendaEventoRequestBody();
            inValue.Body.host = host;
            inValue.Body.puerto = puerto;
            inValue.Body.usuario = usuario;
            inValue.Body.contra = contra;
            inValue.Body.Email = Email;
            inValue.Body.EmailCopia = EmailCopia;
            inValue.Body.from = from;
            inValue.Body.Subject = Subject;
            inValue.Body.body = body;
            inValue.Body.archivoNombre = archivoNombre;
            inValue.Body.EventoTitulo = EventoTitulo;
            inValue.Body.EventoFechaI = EventoFechaI;
            inValue.Body.EventoFechaF = EventoFechaF;
            inValue.Body.EventoOrganizaNombre = EventoOrganizaNombre;
            inValue.Body.EventoOrganizaMail = EventoOrganizaMail;
            inValue.Body.EventoAsunto = EventoAsunto;
            inValue.Body.EventoDescripcion = EventoDescripcion;
            inValue.Body.EventoUbicacion = EventoUbicacion;
            ProyectoBase.Application.WSCorreo.CorreoAsaeCRM_AgendaEventoResponse retVal = ((ProyectoBase.Application.WSCorreo.CorreoSoap)(this)).CorreoAsaeCRM_AgendaEvento(inValue);
            return retVal.Body.CorreoAsaeCRM_AgendaEventoResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ProyectoBase.Application.WSCorreo.CorreoAsaeCRM_AgendaEventoResponse> ProyectoBase.Application.WSCorreo.CorreoSoap.CorreoAsaeCRM_AgendaEventoAsync(ProyectoBase.Application.WSCorreo.CorreoAsaeCRM_AgendaEventoRequest request) {
            return base.Channel.CorreoAsaeCRM_AgendaEventoAsync(request);
        }
        
        public System.Threading.Tasks.Task<ProyectoBase.Application.WSCorreo.CorreoAsaeCRM_AgendaEventoResponse> CorreoAsaeCRM_AgendaEventoAsync(
                    string host, 
                    int puerto, 
                    string usuario, 
                    string contra, 
                    string Email, 
                    string EmailCopia, 
                    string from, 
                    string Subject, 
                    string body, 
                    string archivoNombre, 
                    string EventoTitulo, 
                    System.DateTime EventoFechaI, 
                    System.DateTime EventoFechaF, 
                    string EventoOrganizaNombre, 
                    string EventoOrganizaMail, 
                    string EventoAsunto, 
                    string EventoDescripcion, 
                    string EventoUbicacion) {
            ProyectoBase.Application.WSCorreo.CorreoAsaeCRM_AgendaEventoRequest inValue = new ProyectoBase.Application.WSCorreo.CorreoAsaeCRM_AgendaEventoRequest();
            inValue.Body = new ProyectoBase.Application.WSCorreo.CorreoAsaeCRM_AgendaEventoRequestBody();
            inValue.Body.host = host;
            inValue.Body.puerto = puerto;
            inValue.Body.usuario = usuario;
            inValue.Body.contra = contra;
            inValue.Body.Email = Email;
            inValue.Body.EmailCopia = EmailCopia;
            inValue.Body.from = from;
            inValue.Body.Subject = Subject;
            inValue.Body.body = body;
            inValue.Body.archivoNombre = archivoNombre;
            inValue.Body.EventoTitulo = EventoTitulo;
            inValue.Body.EventoFechaI = EventoFechaI;
            inValue.Body.EventoFechaF = EventoFechaF;
            inValue.Body.EventoOrganizaNombre = EventoOrganizaNombre;
            inValue.Body.EventoOrganizaMail = EventoOrganizaMail;
            inValue.Body.EventoAsunto = EventoAsunto;
            inValue.Body.EventoDescripcion = EventoDescripcion;
            inValue.Body.EventoUbicacion = EventoUbicacion;
            return ((ProyectoBase.Application.WSCorreo.CorreoSoap)(this)).CorreoAsaeCRM_AgendaEventoAsync(inValue);
        }
    }
}
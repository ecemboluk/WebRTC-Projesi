using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace VideoChat
{
    public class VideoComponents : Control
    {
        protected override void Render(HtmlTextWriter writer)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Href, "https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css");
            writer.AddAttribute(HtmlTextWriterAttribute.Type, "text/css");
            writer.AddAttribute(HtmlTextWriterAttribute.Rel, "stylesheet");
            writer.RenderBeginTag(HtmlTextWriterTag.Link);


            string info = getCss("VideoChat.css.style.css");
            writer.RenderBeginTag(HtmlTextWriterTag.Style);
            writer.Write(info);
            writer.RenderEndTag();

            
            //form baslangic
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "form-group");
            writer.RenderBeginTag(HtmlTextWriterTag.Form);
            //label baslangic

            writer.AddAttribute(HtmlTextWriterAttribute.Class, "label1");
            writer.RenderBeginTag(HtmlTextWriterTag.Label);
            writer.Write("Çağrı Başlatılacak Kişiyi Girin:");
            writer.RenderEndTag();
            /*label son */
            writer.AddAttribute(HtmlTextWriterAttribute.Type, "text");
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "form-control text1");
            writer.AddAttribute(HtmlTextWriterAttribute.Id, "callee");
            writer.RenderBeginTag(HtmlTextWriterTag.Input);
            writer.RenderEndTag();
            // buton baslangic

            writer.AddAttribute(HtmlTextWriterAttribute.Type,"button");
            writer.AddAttribute(HtmlTextWriterAttribute.Id, "make-call");
            writer.AddAttribute(HtmlTextWriterAttribute.Onclick, "startCall();");
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "btn btn-success cagributon");
            writer.RenderBeginTag(HtmlTextWriterTag.Button);
            writer.Write("Çağrıyı Başlat");
            writer.RenderEndTag(); // Buton bitiş

            writer.AddAttribute(HtmlTextWriterAttribute.Type, "button");
            writer.AddAttribute(HtmlTextWriterAttribute.Id, "mute-call");
            writer.AddAttribute("disabled", "");
            writer.AddAttribute(HtmlTextWriterAttribute.Onclick, "toggleMute();");
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "btn btn-info");
            writer.RenderBeginTag(HtmlTextWriterTag.Button);
            writer.Write("Mute");
            writer.RenderEndTag(); // Buton bitiş


            writer.AddAttribute(HtmlTextWriterAttribute.Type, "button");
            writer.AddAttribute(HtmlTextWriterAttribute.Id, "hold-call");
            writer.AddAttribute("disabled", "");
            writer.AddAttribute(HtmlTextWriterAttribute.Onclick, "toggleHold();");
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "btn btn-info");
            writer.RenderBeginTag(HtmlTextWriterTag.Button);
            writer.Write("hold/unhold");
            writer.RenderEndTag(); // Buton bitiş


            writer.AddAttribute(HtmlTextWriterAttribute.Type, "button");
            writer.AddAttribute(HtmlTextWriterAttribute.Id, "show-video");
            writer.AddAttribute(HtmlTextWriterAttribute.Onclick, "toggleVideo();");
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "btn btn-info");
            writer.RenderBeginTag(HtmlTextWriterTag.Button);
            writer.Write("show");
            writer.RenderEndTag(); // Buton bitiş

            writer.AddAttribute(HtmlTextWriterAttribute.Type, "button");
            writer.AddAttribute(HtmlTextWriterAttribute.Id, "accept-call");
            writer.AddAttribute("disabled","");
            writer.AddAttribute(HtmlTextWriterAttribute.Onclick, "acceptCall();");
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "btn btn-info");
            writer.RenderBeginTag(HtmlTextWriterTag.Button);
            writer.Write("Çağrı Kabul");
            writer.RenderEndTag(); // Buton bitiş

            writer.AddAttribute(HtmlTextWriterAttribute.Type, "button");
            writer.AddAttribute(HtmlTextWriterAttribute.Id, "decline-call");
            writer.AddAttribute("disabled", "");
            writer.AddAttribute(HtmlTextWriterAttribute.Onclick, "declineCall();");
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "btn btn-info");
            writer.RenderBeginTag(HtmlTextWriterTag.Button);
            writer.Write("Çağrı Reddet");
            writer.RenderEndTag(); // Buton bitiş

            writer.AddAttribute(HtmlTextWriterAttribute.Type, "button");
            writer.AddAttribute(HtmlTextWriterAttribute.Id, "end-call");
            writer.AddAttribute("disabled", "");
            writer.AddAttribute(HtmlTextWriterAttribute.Onclick, "endCall();");
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "btn btn-info");
            writer.RenderBeginTag(HtmlTextWriterTag.Button);
            writer.Write("Çağrıyı Sonlandır");
            writer.RenderEndTag(); // Buton bitiş

            writer.AddAttribute(HtmlTextWriterAttribute.Id, "local-container");
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "camera1");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
            writer.RenderEndTag();

            writer.AddAttribute(HtmlTextWriterAttribute.Id, "remote-container");
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "camera2");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
            writer.RenderEndTag();
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "container chatayar");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "row");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);

            writer.AddAttribute(HtmlTextWriterAttribute.Class, "col-md-5");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);

            writer.AddAttribute(HtmlTextWriterAttribute.Class, "panel panel-primary");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);

            writer.AddAttribute(HtmlTextWriterAttribute.Class, "panel-heading");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);

            writer.AddAttribute(HtmlTextWriterAttribute.Class, "glyphicon glyphicon-comment");
            writer.RenderBeginTag(HtmlTextWriterTag.Span);
            writer.Write("Chat");
            writer.RenderEndTag();
            writer.RenderEndTag();

            writer.AddAttribute(HtmlTextWriterAttribute.Id, "messages");
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "panel-body");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
            writer.RenderEndTag();

            writer.AddAttribute(HtmlTextWriterAttribute.Class, "panel-footer");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);

            writer.AddAttribute(HtmlTextWriterAttribute.Class, "input-group");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);

            writer.AddAttribute(HtmlTextWriterAttribute.Id, "btn-input");
            writer.AddAttribute(HtmlTextWriterAttribute.Type, "text");
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "form-control input-sm");
            writer.RenderBeginTag(HtmlTextWriterTag.Input);
            writer.RenderEndTag();

            writer.RenderEndTag();
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "btn btn-warning btn-sm");
            writer.AddAttribute(HtmlTextWriterAttribute.Id, "btn-chat");
            writer.AddAttribute(HtmlTextWriterAttribute.Value, "Gönder");
            writer.AddAttribute(HtmlTextWriterAttribute.Onclick, "sendMessage();");
            writer.AddAttribute(HtmlTextWriterAttribute.Type, "button");
            writer.RenderBeginTag(HtmlTextWriterTag.Input);
            writer.RenderEndTag();
            writer.RenderEndTag();


            writer.RenderEndTag();
            writer.RenderEndTag();
            writer.RenderEndTag();
            writer.RenderEndTag();
            writer.RenderEndTag();

            //kisiler

            writer.AddAttribute(HtmlTextWriterAttribute.Class, "container kisilerayar");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);

            writer.AddAttribute(HtmlTextWriterAttribute.Class, "row");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);

            writer.AddAttribute(HtmlTextWriterAttribute.Class, "panel panel-primary filterable");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);

            writer.AddAttribute(HtmlTextWriterAttribute.Class, "panel-heading");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);

            writer.AddAttribute(HtmlTextWriterAttribute.Class, "panel-title");
            writer.RenderBeginTag(HtmlTextWriterTag.H3);
            writer.Write("Konuşmacılar");
            writer.RenderEndTag(); //h3 son

            writer.RenderEndTag(); //panel-heading son

            writer.AddAttribute(HtmlTextWriterAttribute.Class, "table");
            writer.RenderBeginTag(HtmlTextWriterTag.Table);
            writer.RenderBeginTag(HtmlTextWriterTag.Thead);

            writer.AddAttribute(HtmlTextWriterAttribute.Class, "filters");
            writer.RenderBeginTag(HtmlTextWriterTag.Tr);

            writer.RenderBeginTag(HtmlTextWriterTag.Th);

            writer.AddAttribute(HtmlTextWriterAttribute.Class, "form-control");
            writer.AddAttribute(HtmlTextWriterAttribute.Type, "text");
            writer.AddAttribute("placeholder", "Kullanıcı Adı");
            writer.AddAttribute("disabled", "");
            writer.RenderBeginTag(HtmlTextWriterTag.Input);
            writer.RenderEndTag(); //input kapama

            writer.RenderEndTag(); // th kapama

            writer.RenderBeginTag(HtmlTextWriterTag.Th);

            writer.AddAttribute(HtmlTextWriterAttribute.Class, "form-control");
            writer.AddAttribute(HtmlTextWriterAttribute.Type, "text");
            writer.AddAttribute("placeholder", "Aç/Kapa");
            writer.AddAttribute("disabled", "");
            writer.RenderBeginTag(HtmlTextWriterTag.Input);
            writer.RenderEndTag(); //input kapama

            writer.RenderEndTag(); // th kapama

            writer.RenderEndTag(); // tr kapama
            writer.RenderEndTag(); //thead kapama

            writer.RenderBeginTag(HtmlTextWriterTag.Tbody);
            writer.RenderBeginTag(HtmlTextWriterTag.Tr);
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            writer.Write("user1@1yalcinsahin1.gmail.com");
            writer.RenderEndTag(); //td kapama

            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "glyphicon glyphicon-facetime-video offcamera");
            writer.AddAttribute(HtmlTextWriterAttribute.Onclick, "toggleVideo();");
            writer.RenderBeginTag(HtmlTextWriterTag.Span);
            writer.RenderEndTag(); //span kapama
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "glyphicon glyphicon-volume-off offcamera");
            writer.AddAttribute(HtmlTextWriterAttribute.Onclick, "toggleMute();");
            writer.RenderBeginTag(HtmlTextWriterTag.Span);
            writer.RenderEndTag(); //span kapama
            writer.RenderEndTag(); //td kapama


            writer.RenderEndTag(); // tr kapama

            writer.RenderBeginTag(HtmlTextWriterTag.Tr);
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            writer.Write("user2@1yalcinsahin1.gmail.com");
            writer.RenderEndTag(); //td kapama

            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "glyphicon glyphicon-facetime-video offcamera");
            writer.AddAttribute(HtmlTextWriterAttribute.Onclick, "toggleVideo();");
            writer.RenderBeginTag(HtmlTextWriterTag.Span);
            writer.RenderEndTag(); //span kapama
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "glyphicon glyphicon-volume-off offcamera");
            writer.AddAttribute(HtmlTextWriterAttribute.Onclick, "toggleMute();");
            writer.RenderBeginTag(HtmlTextWriterTag.Span);
            writer.RenderEndTag(); //span kapama
            writer.RenderEndTag(); //td kapama


            writer.RenderEndTag(); // tr kapama

            writer.RenderEndTag();
            writer.RenderEndTag();
            writer.RenderEndTag();

            writer.RenderEndTag();
            writer.RenderEndTag();

            


            writer.RenderEndTag(); // Form Bitiş


            writer.AddAttribute(HtmlTextWriterAttribute.Type, "text/javascript");
            writer.AddAttribute(HtmlTextWriterAttribute.Src, "https://kandy-portal.s3.amazonaws.com/public/javascript/kandy/2.6.0/kandy.js");
            writer.RenderBeginTag(HtmlTextWriterTag.Script);
            writer.RenderEndTag();

            #region Benim JS Dosyam Ekle

            string info2 = getCss("VideoChat.JavaScript.Message.js");
            writer.AddAttribute(HtmlTextWriterAttribute.Type, "text/javascript");
            writer.RenderBeginTag(HtmlTextWriterTag.Script);
            writer.Write(info2);
            writer.RenderEndTag();

            string info3 = getCss("VideoChat.JavaScript.Chat.js");
            writer.AddAttribute(HtmlTextWriterAttribute.Type, "text/javascript");
            writer.RenderBeginTag(HtmlTextWriterTag.Script);
            writer.Write(info3);
            writer.RenderEndTag();
            #endregion Benim JS Dosyam Ekle




            base.Render(writer);
        }


        public string getCss(string fullName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (Stream stream = assembly.GetManifestResourceStream(fullName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}

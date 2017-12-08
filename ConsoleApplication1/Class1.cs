using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Diagnostics.Contracts;

namespace ConsoleApplication1
{
    public class TelnetSession : AppSession<TelnetSession, YourRequestInfo>
    {
        protected override void OnSessionStarted()
        {
            this.Send("Welcome to SuperSocket Telnet Server?");
        }
        protected override void HandleUnknownRequest(YourRequestInfo requestInfo)
        {
            this.Send("Unknow request??");
        }
        //protected override void HandleUnknownRequest(YourRequestInfo requestInfo)
        //            protected override void OnSessionStarted()

        //protected override void HandleException(Exception e)
        //{
        //    this.Send("Application error123: {0}", e.Message);
        //}

        protected override void OnSessionClosed(CloseReason reason)
        {
            //add you logics which will be executed after the session is closed
            base.OnSessionClosed(reason);
        }
    }

    public class ECHO : CommandBase<TelnetSession, YourRequestInfo>
    {
        public override void ExecuteCommand(TelnetSession session, YourRequestInfo requestInfo)
        {
             session.Send(@"sdfsdf
               AS  ");
        }
        public override string Name
        {
            get
            {
                return base.Name;
            }
        }
    }

    public class PlayerSession : AppSession<PlayerSession>
    {
        public int GameHallId { get; internal set; }

        public int RoomId { get; internal set; }
    }

    public class TelnetServer : AppServer<TelnetSession, YourRequestInfo>
    {
        public TelnetServer():base(new YourReceiveFilterFactory()) {

        }
        protected override bool Setup(IRootConfig rootConfig, IServerConfig config)
        {
            return base.Setup(rootConfig, config);
        }

        protected override void OnStartup()
        {
            base.OnStartup();
        }

        protected override void OnStopped()
        {
            base.OnStopped(); 
        }



    }
 public   class YourRequestInfo:IRequestInfo
    {
        public string Key { get; set; }

        public int DeviceId { get; set; }
        string A { set; get; }

    }
    public class YourReceiveFilterFactory : IReceiveFilterFactory<YourRequestInfo>
    {
        //More code
        public IReceiveFilter<YourRequestInfo> CreateFilter(IAppServer appServer, IAppSession appSession, IPEndPoint remoteEndPoint)
        {
            return new YourReceiveFilter(new byte []{ 67,63,76,65},"test");
        }
    }
    public class YourReceiveFilter : TerminatorReceiveFilter<YourRequestInfo>
    {
        public YourReceiveFilter(byte[] terminator,string dd) : base(terminator)
        {
            NewMethod(dd);
            try
            {

            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void NewMethod(string dd)
        {
            Console.WriteLine(dd);
        }

        //More code
        public override YourRequestInfo Filter(byte[] readBuffer, int offset, int length, bool toBeCopied, out int rest)
        {
            return base.Filter(readBuffer, offset, length, toBeCopied, out rest);
        }

        protected override YourRequestInfo ProcessMatchedRequest(byte[] data, int offset, int length)
        {
            throw new NotImplementedException("NotImplementedException");
        }
    }


}

//using System;

//namespace DelegatesDemo
//{
//    public delegate void DelegateForNotifications(string msg);
//    internal class ALotMoreAboutDelegates
//    {
//        static void Main()
//        {
//            Account acc1  = new Account();
//            DelegateForNotifications subscribe = new DelegateForNotifications(Notification.SendEmail);
//            acc1.Modify(subscribe);
//            acc1.Deposit(10000);
//            subscribe += Notification.sendSMS;
//            acc1.Modify(subscribe);
//            acc1.Withdraw(1000);
//        }
//    }
//    public class Account
//    {
//        public DelegateForNotifications NotifyMe { get; private set; }
//        public int Balance { get; private set; } //Balance cannot be modified; If set is removed then balance is readonly for the Account class also
//        public void Deposit(int amount){ 
//            Balance += amount;
//            //Write code to send email
//            string msg = $"Your account balance has been increased by {amount}";
//            if(NotifyMe!=null)
//                NotifyMe(msg);
//        }
//        public void Withdraw(int amount)
//        {
//            Balance -= amount;
//            //Write code to send email
//            string msg = $"Your account balance has been decreased by {amount}";
//            if(NotifyMe!=null)
//                NotifyMe(msg);
//        }
//        public void Modify(DelegateForNotifications subscribe)
//        {
//            NotifyMe = subscribe;
//        }
//    }
    
//    public class Notification
//    {
//        public static void SendEmail(string msg)
//        {
//            //SmtpClient smtp = new SmtpClient();
//            //smtp.Host = "smtp.gmail.com";//Mail server's address
//            //smtp.Port = 465;
//            //smtp.Credentials = null;
//            //MailMessage mail = new MailMessage();
//            //mail.From = "";
//            //mail.To = "";
//            //mail.Subject = "";
//            //mail.Body = msg;
//            //mail.Attachments.Add("");

//            //smtp.Send(mail);
//            Console.WriteLine($"Mail: {msg}");
//        }
//        public static void sendSMS(string msg)
//        {
//            Console.WriteLine($"SMS: {msg}");
//        }
//    }
//}

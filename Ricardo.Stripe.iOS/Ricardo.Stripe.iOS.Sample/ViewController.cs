using System;
using System.Collections.Generic;
using System.Net.Http;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace Ricardo.Stripe.iOS.Sample
{
    public partial class ViewController : UIViewController, ISTPPaymentContextDelegate
    {
        STPPaymentContext StpPaymentContext;

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void StartPayment(UIButton sender)
        {
            var config = STPPaymentConfiguration.SharedConfiguration();
            config.ShippingType = STPShippingType.Shipping;
            config.RequiredShippingAddressFields = PassKit.PKAddressField.None;

            StpPaymentContext = new STPPaymentContext(new MyAPIClient(), config, STPTheme.DefaultTheme);

            StpPaymentContext.WeakDelegate = this;
            StpPaymentContext.HostViewController = NavigationController;
            StpPaymentContext.PaymentAmount = 1;

            StpPaymentContext.RequestPayment();
        }

        #region ISTPPaymentContextDelegate

        public void PaymentContext(STPPaymentContext paymentContext, NSError error)
        {
        }

        public void PaymentContextDidChange(STPPaymentContext paymentContext)
        {
        }

        public void PaymentContext(STPPaymentContext paymentContext, STPPaymentResult paymentResult, STPErrorBlock completion)
        {
            // TODO: Implement actions for the payment result
        }

        public void PaymentContext(STPPaymentContext paymentContext, STPPaymentStatus status, NSError error)
        {
            // TODO: Implement actions for the payment status change
        }

        #endregion

        public class MyAPIClient : NSObject, ISTPBackendAPIAdapter
        {
            static readonly string baseUrl = "https://your-stripe-api.example.com";
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };

            [Export("attachSourceToCustomer:completion:")]
            public async void AttachSourceToCustomer(ISTPSourceProtocol source, STPErrorBlock completion)
            {
                var kv = new KeyValuePair<string, string>[] {
                new KeyValuePair<string, string>("source", source.StripeID )
            };
                var json = await client.PostAsync("/customer/sources", new FormUrlEncodedContent(kv));

                completion(null);
            }

            public async void RetrieveCustomer(STPCustomerCompletionBlock completion)
            {
                var json = await client.GetStringAsync("/customer");
                var data = NSData.FromString(json, NSStringEncoding.UTF8);
                var deserializer = new STPCustomerDeserializer(data, null, null);

                completion(deserializer.Customer, null);
            }

            [Export("selectDefaultCustomerSource:completion:")]
            public async void SelectDefaultCustomerSource(ISTPSourceProtocol source, STPErrorBlock completion)
            {
                var kv = new KeyValuePair<string, string>[] {
                new KeyValuePair<string, string>("source", source.StripeID )
            };
                var json = await client.PostAsync("/customer/default_source", new FormUrlEncodedContent(kv));

                completion(null);
            }
        }
    }
}

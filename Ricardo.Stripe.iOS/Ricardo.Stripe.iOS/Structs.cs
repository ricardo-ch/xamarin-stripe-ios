using System;
using System.Runtime.InteropServices;
using ObjCRuntime;

namespace Ricardo.Stripe.iOS
{
    [Native]
    public enum STPShippingType : long
    {
        Shipping,
        Delivery
    }

    [Native]
    public enum STPShippingStatus : long
    {
        Valid,
        Invalid
    }

    [Native]
    public enum STPPaymentStatus : long
    {
        Success,
        Error,
        UserCancellation
    }

    [Native]
    public enum STPFilePurpose : long
    {
        IdentityDocument,
        DisputeEvidence,
        Unknown
    }

    static class CFunctions
    {
        // extern void linkSTPAPIClientApplePayCategory ();
        [DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern void linkSTPAPIClientApplePayCategory ();

        // extern void linkNSErrorCategory ();
        [DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern void linkNSErrorCategory ();

        // extern void linkUINavigationBarThemeCategory ();
        [DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern void linkUINavigationBarThemeCategory ();
    }

    [Native]
    public enum STPBillingAddressFields : long
    {
        None,
        Zip,
        Full
    }

    [Native]
    public enum STPPaymentMethodType : long
    {
        None = 0,
        ApplePay = 1 << 0,
        All = ApplePay
    }

    [Native]
    public enum STPBankAccountHolderType : long
    {
        Individual,
        Company
    }

    [Native]
    public enum STPBankAccountStatus : long
    {
        New,
        Validated,
        Verified,
        VerificationFailed,
        Errored
    }

    [Native]
    public enum STPCardBrand : long
    {
        Visa,
        Amex,
        MasterCard,
        Discover,
        Jcb,
        DinersClub,
        Unknown
    }

    [Native]
    public enum STPCardFundingType : long
    {
        Debit,
        Credit,
        Prepaid,
        Other
    }

    [Native]
    public enum STPCardValidationState : long
    {
        Valid,
        Invalid,
        Incomplete
    }

    [Native]
    public enum STPRedirectContextState : long
    {
        NotStarted,
        InProgress,
        Cancelled,
        Completed
    }

    [Native]
    public enum STPSourceCard3DSecureStatus : long
    {
        Required,
        Optional,
        NotSupported,
        Unknown
    }

    [Native]
    public enum STPSourceFlow : long
    {
        None,
        Redirect,
        CodeVerification,
        Receiver,
        Unknown
    }

    [Native]
    public enum STPSourceUsage : long
    {
        Reusable,
        SingleUse,
        Unknown
    }

    [Native]
    public enum STPSourceStatus : long
    {
        Pending,
        Chargeable,
        Consumed,
        Canceled,
        Failed,
        Unknown
    }

    [Native]
    public enum STPSourceType : long
    {
        Bancontact,
        Bitcoin,
        Card,
        Giropay,
        Ideal,
        SEPADebit,
        Sofort,
        ThreeDSecure,
        Alipay,
        P24,
        Unknown
    }

    [Native]
    public enum STPSourceRedirectStatus : long
    {
        Pending,
        Succeeded,
        Failed,
        Unknown
    }

    [Native]
    public enum STPSourceVerificationStatus : long
    {
        Pending,
        Succeeded,
        Failed,
        Unknown
    }

    [Native]
    public enum STPErrorCode : long
    {
        ConnectionError = 40,
        InvalidRequestError = 50,
        APIError = 60,
        CardError = 70,
        CancellationError = 80,
        EphemeralKeyDecodingError = 1000
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Web;
using System.IO;
using System.Collections.Specialized;
using System.Web.UI;
using System.Security.Principal;
using System.Web.Caching;
using System.Runtime.Serialization;
using System.Web.SessionState;
using System.Web.Profile;
using System.Globalization;
using NLite.Net;

namespace NLite.Web
{
    public abstract class HttpStaticObjectsCollectionBase :System.Web.HttpStaticObjectsCollectionBase, IHttpStaticObjectsCollection
    {
       
    }
   
    public class HttpStaticObjectsCollectionWrapper : HttpStaticObjectsCollectionBase
    {
        private HttpStaticObjectsCollection _collection;
        public override int Count
        {
            get
            {
                return this._collection.Count;
            }
        }
        public override bool IsReadOnly
        {
            get
            {
                return this._collection.IsReadOnly;
            }
        }
        public override bool IsSynchronized
        {
            get
            {
                return this._collection.IsSynchronized;
            }
        }
        public override object this[string name]
        {
            get
            {
                return this._collection[name];
            }
        }
        public override bool NeverAccessed
        {
            get
            {
                return this._collection.NeverAccessed;
            }
        }
        public override object SyncRoot
        {
            get
            {
                return this._collection.SyncRoot;
            }
        }
        public HttpStaticObjectsCollectionWrapper(HttpStaticObjectsCollection httpStaticObjectsCollection)
        {
            if (httpStaticObjectsCollection == null)
            {
                throw new ArgumentNullException("httpStaticObjectsCollection");
            }
            this._collection = httpStaticObjectsCollection;
        }
        public override void CopyTo(Array array, int index)
        {
            this._collection.CopyTo(array, index);
        }
        public override IEnumerator GetEnumerator()
        {
            return this._collection.GetEnumerator();
        }
        public override object GetObject(string name)
        {
            return this._collection.GetObject(name);
        }
        public override void Serialize(BinaryWriter writer)
        {
            this._collection.Serialize(writer);
        }
    }

   
    public abstract class HttpApplicationStateBase : System.Web.HttpApplicationStateBase, IHttpApplicationState
    {
        IHttpApplicationState IHttpApplicationState.Contents
        {
            get { return this as IHttpApplicationState; }
        }

        IHttpStaticObjectsCollection IHttpApplicationState.StaticObjects
        {
            get { return base.StaticObjects as IHttpStaticObjectsCollection; }
        }
    }

    public abstract class HttpBrowserCapabilitiesBase : System.Web.HttpBrowserCapabilitiesBase, IHttpBrowserCapabilities
    {
    }

    public class HttpBrowserCapabilitiesWrapper : HttpBrowserCapabilitiesBase
    {
        private HttpBrowserCapabilities _browser;
        public override string Browser
        {
            get
            {
                return this._browser.Browser;
            }
        }
        public override Version EcmaScriptVersion
        {
            get
            {
                return this._browser.EcmaScriptVersion;
            }
        }
        public override Version JScriptVersion
        {
            get
            {
                return this._browser.JScriptVersion;
            }
        }
        public override bool SupportsCallback
        {
            get
            {
                return this._browser.SupportsCallback;
            }
        }
        public override Version W3CDomVersion
        {
            get
            {
                return this._browser.W3CDomVersion;
            }
        }
        public override bool ActiveXControls
        {
            get
            {
                return this._browser.ActiveXControls;
            }
        }
        public override IDictionary Adapters
        {
            get
            {
                return this._browser.Adapters;
            }
        }
        public override bool AOL
        {
            get
            {
                return this._browser.AOL;
            }
        }
        public override bool BackgroundSounds
        {
            get
            {
                return this._browser.BackgroundSounds;
            }
        }
        public override bool Beta
        {
            get
            {
                return this._browser.Beta;
            }
        }
        public override ArrayList Browsers
        {
            get
            {
                return this._browser.Browsers;
            }
        }
        public override bool CanCombineFormsInDeck
        {
            get
            {
                return this._browser.CanCombineFormsInDeck;
            }
        }
        public override bool CanInitiateVoiceCall
        {
            get
            {
                return this._browser.CanInitiateVoiceCall;
            }
        }
        public override bool CanRenderAfterInputOrSelectElement
        {
            get
            {
                return this._browser.CanRenderAfterInputOrSelectElement;
            }
        }
        public override bool CanRenderEmptySelects
        {
            get
            {
                return this._browser.CanRenderEmptySelects;
            }
        }
        public override bool CanRenderInputAndSelectElementsTogether
        {
            get
            {
                return this._browser.CanRenderInputAndSelectElementsTogether;
            }
        }
        public override bool CanRenderMixedSelects
        {
            get
            {
                return this._browser.CanRenderMixedSelects;
            }
        }
        public override bool CanRenderOneventAndPrevElementsTogether
        {
            get
            {
                return this._browser.CanRenderOneventAndPrevElementsTogether;
            }
        }
        public override bool CanRenderPostBackCards
        {
            get
            {
                return this._browser.CanRenderPostBackCards;
            }
        }
        public override bool CanRenderSetvarZeroWithMultiSelectionList
        {
            get
            {
                return this._browser.CanRenderSetvarZeroWithMultiSelectionList;
            }
        }
        public override bool CanSendMail
        {
            get
            {
                return this._browser.CanSendMail;
            }
        }
        public override IDictionary Capabilities
        {
            get
            {
                return this._browser.Capabilities;
            }
            set
            {
                this._browser.Capabilities = value;
            }
        }
        public override bool CDF
        {
            get
            {
                return this._browser.CDF;
            }
        }
        public override Version ClrVersion
        {
            get
            {
                return this._browser.ClrVersion;
            }
        }
        public override bool Cookies
        {
            get
            {
                return this._browser.Cookies;
            }
        }
        public override bool Crawler
        {
            get
            {
                return this._browser.Crawler;
            }
        }
        public override int DefaultSubmitButtonLimit
        {
            get
            {
                return this._browser.DefaultSubmitButtonLimit;
            }
        }
        public override bool Frames
        {
            get
            {
                return this._browser.Frames;
            }
        }
        public override int GatewayMajorVersion
        {
            get
            {
                return this._browser.GatewayMajorVersion;
            }
        }
        public override double GatewayMinorVersion
        {
            get
            {
                return this._browser.GatewayMinorVersion;
            }
        }
        public override string GatewayVersion
        {
            get
            {
                return this._browser.GatewayVersion;
            }
        }
        public override bool HasBackButton
        {
            get
            {
                return this._browser.HasBackButton;
            }
        }
        public override bool HidesRightAlignedMultiselectScrollbars
        {
            get
            {
                return this._browser.HidesRightAlignedMultiselectScrollbars;
            }
        }
        public override string HtmlTextWriter
        {
            get
            {
                return this._browser.HtmlTextWriter;
            }
            set
            {
                this._browser.HtmlTextWriter = value;
            }
        }
        public override string Id
        {
            get
            {
                return this._browser.Id;
            }
        }
        public override string InputType
        {
            get
            {
                return this._browser.InputType;
            }
        }
        public override bool IsColor
        {
            get
            {
                return this._browser.IsColor;
            }
        }
        public override bool IsMobileDevice
        {
            get
            {
                return this._browser.IsMobileDevice;
            }
        }
        public override bool JavaApplets
        {
            get
            {
                return this._browser.JavaApplets;
            }
        }
        public override int MajorVersion
        {
            get
            {
                return this._browser.MajorVersion;
            }
        }
        public override int MaximumHrefLength
        {
            get
            {
                return this._browser.MaximumHrefLength;
            }
        }
        public override int MaximumRenderedPageSize
        {
            get
            {
                return this._browser.MaximumRenderedPageSize;
            }
        }
        public override int MaximumSoftkeyLabelLength
        {
            get
            {
                return this._browser.MaximumSoftkeyLabelLength;
            }
        }
        public override double MinorVersion
        {
            get
            {
                return this._browser.MinorVersion;
            }
        }
        public override string MinorVersionString
        {
            get
            {
                return this._browser.MinorVersionString;
            }
        }
        public override string MobileDeviceManufacturer
        {
            get
            {
                return this._browser.MobileDeviceManufacturer;
            }
        }
        public override string MobileDeviceModel
        {
            get
            {
                return this._browser.MobileDeviceModel;
            }
        }
        public override Version MSDomVersion
        {
            get
            {
                return this._browser.MSDomVersion;
            }
        }
        public override int NumberOfSoftkeys
        {
            get
            {
                return this._browser.NumberOfSoftkeys;
            }
        }
        public override string Platform
        {
            get
            {
                return this._browser.Platform;
            }
        }
        public override string PreferredImageMime
        {
            get
            {
                return this._browser.PreferredImageMime;
            }
        }
        public override string PreferredRenderingMime
        {
            get
            {
                return this._browser.PreferredRenderingMime;
            }
        }
        public override string PreferredRenderingType
        {
            get
            {
                return this._browser.PreferredRenderingType;
            }
        }
        public override string PreferredRequestEncoding
        {
            get
            {
                return this._browser.PreferredRequestEncoding;
            }
        }
        public override string PreferredResponseEncoding
        {
            get
            {
                return this._browser.PreferredResponseEncoding;
            }
        }
        public override bool RendersBreakBeforeWmlSelectAndInput
        {
            get
            {
                return this._browser.RendersBreakBeforeWmlSelectAndInput;
            }
        }
        public override bool RendersBreaksAfterHtmlLists
        {
            get
            {
                return this._browser.RendersBreaksAfterHtmlLists;
            }
        }
        public override bool RendersBreaksAfterWmlAnchor
        {
            get
            {
                return this._browser.RendersBreaksAfterWmlAnchor;
            }
        }
        public override bool RendersBreaksAfterWmlInput
        {
            get
            {
                return this._browser.RendersBreaksAfterWmlInput;
            }
        }
        public override bool RendersWmlDoAcceptsInline
        {
            get
            {
                return this._browser.RendersWmlDoAcceptsInline;
            }
        }
        public override bool RendersWmlSelectsAsMenuCards
        {
            get
            {
                return this._browser.RendersWmlSelectsAsMenuCards;
            }
        }
        public override string RequiredMetaTagNameValue
        {
            get
            {
                return this._browser.RequiredMetaTagNameValue;
            }
        }
        public override bool RequiresAttributeColonSubstitution
        {
            get
            {
                return this._browser.RequiresAttributeColonSubstitution;
            }
        }
        public override bool RequiresContentTypeMetaTag
        {
            get
            {
                return this._browser.RequiresContentTypeMetaTag;
            }
        }
        public override bool RequiresControlStateInSession
        {
            get
            {
                return this._browser.RequiresControlStateInSession;
            }
        }
        public override bool RequiresDBCSCharacter
        {
            get
            {
                return this._browser.RequiresDBCSCharacter;
            }
        }
        public override bool RequiresHtmlAdaptiveErrorReporting
        {
            get
            {
                return this._browser.RequiresHtmlAdaptiveErrorReporting;
            }
        }
        public override bool RequiresLeadingPageBreak
        {
            get
            {
                return this._browser.RequiresLeadingPageBreak;
            }
        }
        public override bool RequiresNoBreakInFormatting
        {
            get
            {
                return this._browser.RequiresNoBreakInFormatting;
            }
        }
        public override bool RequiresOutputOptimization
        {
            get
            {
                return this._browser.RequiresOutputOptimization;
            }
        }
        public override bool RequiresPhoneNumbersAsPlainText
        {
            get
            {
                return this._browser.RequiresPhoneNumbersAsPlainText;
            }
        }
        public override bool RequiresSpecialViewStateEncoding
        {
            get
            {
                return this._browser.RequiresSpecialViewStateEncoding;
            }
        }
        public override bool RequiresUniqueFilePathSuffix
        {
            get
            {
                return this._browser.RequiresUniqueFilePathSuffix;
            }
        }
        public override bool RequiresUniqueHtmlCheckboxNames
        {
            get
            {
                return this._browser.RequiresUniqueHtmlCheckboxNames;
            }
        }
        public override bool RequiresUniqueHtmlInputNames
        {
            get
            {
                return this._browser.RequiresUniqueHtmlInputNames;
            }
        }
        public override bool RequiresUrlEncodedPostfieldValues
        {
            get
            {
                return this._browser.RequiresUrlEncodedPostfieldValues;
            }
        }
        public override int ScreenBitDepth
        {
            get
            {
                return this._browser.ScreenBitDepth;
            }
        }
        public override int ScreenCharactersHeight
        {
            get
            {
                return this._browser.ScreenCharactersHeight;
            }
        }
        public override int ScreenCharactersWidth
        {
            get
            {
                return this._browser.ScreenCharactersWidth;
            }
        }
        public override int ScreenPixelsHeight
        {
            get
            {
                return this._browser.ScreenPixelsHeight;
            }
        }
        public override int ScreenPixelsWidth
        {
            get
            {
                return this._browser.ScreenPixelsWidth;
            }
        }
        public override bool SupportsAccesskeyAttribute
        {
            get
            {
                return this._browser.SupportsAccesskeyAttribute;
            }
        }
        public override bool SupportsBodyColor
        {
            get
            {
                return this._browser.SupportsBodyColor;
            }
        }
        public override bool SupportsBold
        {
            get
            {
                return this._browser.SupportsBold;
            }
        }
        public override bool SupportsCacheControlMetaTag
        {
            get
            {
                return this._browser.SupportsCacheControlMetaTag;
            }
        }
        public override bool SupportsCss
        {
            get
            {
                return this._browser.SupportsCss;
            }
        }
        public override bool SupportsDivAlign
        {
            get
            {
                return this._browser.SupportsDivAlign;
            }
        }
        public override bool SupportsDivNoWrap
        {
            get
            {
                return this._browser.SupportsDivNoWrap;
            }
        }
        public override bool SupportsEmptyStringInCookieValue
        {
            get
            {
                return this._browser.SupportsEmptyStringInCookieValue;
            }
        }
        public override bool SupportsFontColor
        {
            get
            {
                return this._browser.SupportsFontColor;
            }
        }
        public override bool SupportsFontName
        {
            get
            {
                return this._browser.SupportsFontName;
            }
        }
        public override bool SupportsFontSize
        {
            get
            {
                return this._browser.SupportsFontSize;
            }
        }
        public override bool SupportsImageSubmit
        {
            get
            {
                return this._browser.SupportsImageSubmit;
            }
        }
        public override bool SupportsIModeSymbols
        {
            get
            {
                return this._browser.SupportsIModeSymbols;
            }
        }
        public override bool SupportsInputIStyle
        {
            get
            {
                return this._browser.SupportsInputIStyle;
            }
        }
        public override bool SupportsInputMode
        {
            get
            {
                return this._browser.SupportsInputMode;
            }
        }
        public override bool SupportsItalic
        {
            get
            {
                return this._browser.SupportsItalic;
            }
        }
        public override bool SupportsJPhoneMultiMediaAttributes
        {
            get
            {
                return this._browser.SupportsJPhoneMultiMediaAttributes;
            }
        }
        public override bool SupportsJPhoneSymbols
        {
            get
            {
                return this._browser.SupportsJPhoneSymbols;
            }
        }
        public override bool SupportsQueryStringInFormAction
        {
            get
            {
                return this._browser.SupportsQueryStringInFormAction;
            }
        }
        public override bool SupportsRedirectWithCookie
        {
            get
            {
                return this._browser.SupportsRedirectWithCookie;
            }
        }
        public override bool SupportsSelectMultiple
        {
            get
            {
                return this._browser.SupportsSelectMultiple;
            }
        }
        public override bool SupportsUncheck
        {
            get
            {
                return this._browser.SupportsUncheck;
            }
        }
        public override bool SupportsXmlHttp
        {
            get
            {
                return this._browser.SupportsXmlHttp;
            }
        }
        public override bool Tables
        {
            get
            {
                return this._browser.Tables;
            }
        }
        public override Type TagWriter
        {
            get
            {
                return this._browser.TagWriter;
            }
        }
        public override string Type
        {
            get
            {
                return this._browser.Type;
            }
        }
        public override bool UseOptimizedCacheKey
        {
            get
            {
                return this._browser.UseOptimizedCacheKey;
            }
        }
        public override bool VBScript
        {
            get
            {
                return this._browser.VBScript;
            }
        }
        public override string Version
        {
            get
            {
                return this._browser.Version;
            }
        }
        public override bool Win16
        {
            get
            {
                return this._browser.Win16;
            }
        }
        public override bool Win32
        {
            get
            {
                return this._browser.Win32;
            }
        }
        public override string this[string key]
        {
            get
            {
                return this._browser[key];
            }
        }
        public HttpBrowserCapabilitiesWrapper(HttpBrowserCapabilities httpBrowserCapabilities)
        {
            if (httpBrowserCapabilities == null)
            {
                throw new ArgumentNullException("httpBrowserCapabilities");
            }
            this._browser = httpBrowserCapabilities;
        }
        public override void AddBrowser(string browserName)
        {
            this._browser.AddBrowser(browserName);
        }
        public override HtmlTextWriter CreateHtmlTextWriter(TextWriter w)
        {
            return this._browser.CreateHtmlTextWriter(w);
        }
        public override void DisableOptimizedCacheKey()
        {
            this._browser.DisableOptimizedCacheKey();
        }
        public override Version[] GetClrVersions()
        {
            return this._browser.GetClrVersions();
        }
        public override bool IsBrowser(string browserName)
        {
            return this._browser.IsBrowser(browserName);
        }
        public override int CompareFilters(string filter1, string filter2)
        {
            return ((IFilterResolutionService)this._browser).CompareFilters(filter1, filter2);
        }
        public override bool EvaluateFilter(string filterName)
        {
            return ((IFilterResolutionService)this._browser).EvaluateFilter(filterName);
        }
    }

    public abstract class HttpCachePolicyBase :System.Web.HttpCachePolicyBase, IHttpCachePolicy
    {
       
    }

    public class HttpCachePolicyWrapper : HttpCachePolicyBase
    {
        private HttpCachePolicy _httpCachePolicy;
        public override HttpCacheVaryByContentEncodings VaryByContentEncodings
        {
            get
            {
                return this._httpCachePolicy.VaryByContentEncodings;
            }
        }
        public override HttpCacheVaryByHeaders VaryByHeaders
        {
            get
            {
                return this._httpCachePolicy.VaryByHeaders;
            }
        }
        public override HttpCacheVaryByParams VaryByParams
        {
            get
            {
                return this._httpCachePolicy.VaryByParams;
            }
        }
        public HttpCachePolicyWrapper(HttpCachePolicy httpCachePolicy)
        {
            if (httpCachePolicy == null)
            {
                throw new ArgumentNullException("httpCachePolicy");
            }
            this._httpCachePolicy = httpCachePolicy;
        }
        public override void AddValidationCallback(HttpCacheValidateHandler handler, object data)
        {
            this._httpCachePolicy.AddValidationCallback(handler, data);
        }
        public override void AppendCacheExtension(string extension)
        {
            this._httpCachePolicy.AppendCacheExtension(extension);
        }
        public override void SetAllowResponseInBrowserHistory(bool allow)
        {
            this._httpCachePolicy.SetAllowResponseInBrowserHistory(allow);
        }
        public override void SetCacheability(HttpCacheability cacheability)
        {
            this._httpCachePolicy.SetCacheability(cacheability);
        }
        public override void SetCacheability(HttpCacheability cacheability, string field)
        {
            this._httpCachePolicy.SetCacheability(cacheability, field);
        }
        public override void SetETag(string etag)
        {
            this._httpCachePolicy.SetETag(etag);
        }
        public override void SetETagFromFileDependencies()
        {
            this._httpCachePolicy.SetETagFromFileDependencies();
        }
        public override void SetExpires(DateTime date)
        {
            this._httpCachePolicy.SetExpires(date);
        }
        public override void SetLastModified(DateTime date)
        {
            this._httpCachePolicy.SetLastModified(date);
        }
        public override void SetLastModifiedFromFileDependencies()
        {
            this._httpCachePolicy.SetLastModifiedFromFileDependencies();
        }
        public override void SetMaxAge(TimeSpan delta)
        {
            this._httpCachePolicy.SetMaxAge(delta);
        }
        public override void SetNoServerCaching()
        {
            this._httpCachePolicy.SetNoServerCaching();
        }
        public override void SetNoStore()
        {
            this._httpCachePolicy.SetNoStore();
        }
        public override void SetNoTransforms()
        {
            this._httpCachePolicy.SetNoTransforms();
        }
        public override void SetOmitVaryStar(bool omit)
        {
            this._httpCachePolicy.SetOmitVaryStar(omit);
        }
        public override void SetProxyMaxAge(TimeSpan delta)
        {
            this._httpCachePolicy.SetProxyMaxAge(delta);
        }
        public override void SetRevalidation(HttpCacheRevalidation revalidation)
        {
            this._httpCachePolicy.SetRevalidation(revalidation);
        }
        public override void SetSlidingExpiration(bool slide)
        {
            this._httpCachePolicy.SetSlidingExpiration(slide);
        }
        public override void SetValidUntilExpires(bool validUntilExpires)
        {
            this._httpCachePolicy.SetValidUntilExpires(validUntilExpires);
        }
        public override void SetVaryByCustom(string custom)
        {
            this._httpCachePolicy.SetVaryByCustom(custom);
        }
    }

    public abstract class HttpPostedFileBase : System.Web.HttpPostedFileBase, IHttpPostedFile
    {
    }

    public class HttpPostedFileWrapper : HttpPostedFileBase
    {
        private HttpPostedFile _file;
        public override int ContentLength
        {
            get
            {
                return this._file.ContentLength;
            }
        }
        public override string ContentType
        {
            get
            {
                return this._file.ContentType;
            }
        }
        public override string FileName
        {
            get
            {
                return this._file.FileName;
            }
        }
        public override Stream InputStream
        {
            get
            {
                return this._file.InputStream;
            }
        }
        public HttpPostedFileWrapper(HttpPostedFile httpPostedFile)
        {
            if (httpPostedFile == null)
            {
                throw new ArgumentNullException("httpPostedFile");
            }
            this._file = httpPostedFile;
        }
        public override void SaveAs(string filename)
        {
            this._file.SaveAs(filename);
        }
    }

    public abstract class HttpFileCollectionBase : System.Web.HttpFileCollectionBase, IHttpFileCollection
    {
        IHttpPostedFile IHttpFileCollection.this[string name]
        {
            get
            {
                return this[name] as IHttpPostedFile;
            }
        }
        IHttpPostedFile IHttpFileCollection.this[int index]
        {
            get
            {
                return this[index] as IHttpPostedFile;
            }
        }

        IHttpPostedFile IHttpFileCollection.Get(int index)
        {
            return Get(index) as IHttpPostedFile;
        }
        IHttpPostedFile IHttpFileCollection.Get(string name)
        {
            return Get(name) as IHttpPostedFile;
        }
       
    }

    public class HttpFileCollectionWrapper : HttpFileCollectionBase
    {
        private HttpFileCollection _collection;
        public override string[] AllKeys
        {
            get
            {
                return this._collection.AllKeys;
            }
        }
        public override int Count
        {
            get
            {
                return ((ICollection)this._collection).Count;
            }
        }
        public override bool IsSynchronized
        {
            get
            {
                return ((ICollection)this._collection).IsSynchronized;
            }
        }
        public override NameObjectCollectionBase.KeysCollection Keys
        {
            get
            {
                return this._collection.Keys;
            }
        }
        public override object SyncRoot
        {
            get
            {
                return ((ICollection)this._collection).SyncRoot;
            }
        }
        public override System.Web.HttpPostedFileBase this[string name]
        {
            get
            {
                HttpPostedFile httpPostedFile = this._collection[name];
                if (httpPostedFile == null)
                {
                    return null;
                }
                return new HttpPostedFileWrapper(httpPostedFile);
            }
        }
        public override System.Web.HttpPostedFileBase this[int index]
        {
            get
            {
                HttpPostedFile httpPostedFile = this._collection[index];
                if (httpPostedFile == null)
                {
                    return null;
                }
                return new HttpPostedFileWrapper(httpPostedFile);
            }
        }
        public HttpFileCollectionWrapper(HttpFileCollection httpFileCollection)
        {
            if (httpFileCollection == null)
            {
                throw new ArgumentNullException("httpFileCollection");
            }
            this._collection = httpFileCollection;
        }
        public override void CopyTo(Array dest, int index)
        {
            this._collection.CopyTo(dest, index);
        }
        public override System.Web.HttpPostedFileBase Get(int index)
        {
            HttpPostedFile httpPostedFile = this._collection.Get(index);
            if (httpPostedFile == null)
            {
                return null;
            }
            return new HttpPostedFileWrapper(httpPostedFile);
        }
        public override System.Web.HttpPostedFileBase Get(string name)
        {
            HttpPostedFile httpPostedFile = this._collection.Get(name);
            if (httpPostedFile == null)
            {
                return null;
            }
            return new HttpPostedFileWrapper(httpPostedFile);
        }
        public override IEnumerator GetEnumerator()
        {
            return ((IEnumerable)this._collection).GetEnumerator();
        }
        public override string GetKey(int index)
        {
            return this._collection.GetKey(index);
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            this._collection.GetObjectData(info, context);
        }
        public override void OnDeserialization(object sender)
        {
            this._collection.OnDeserialization(sender);
        }
    }

    public abstract class HttpRequestBase : System.Web.HttpRequestBase, IHttpRequest
    {

        IHttpBrowserCapabilities IHttpRequest.Browser
        {
            get
            {
                return Browser as IHttpBrowserCapabilities;
            }
        }
        //public virtual HttpClientCertificate ClientCertificate
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        IHttpFileCollection IHttpRequest.Files
        {
            get
            {
                return Files as IHttpFileCollection;
            }
        }


        private IHttpCookieCollection cookiesWrapper;
        IHttpCookieCollection IHttpRequest.Cookies
        {
            get
            {
                if (cookiesWrapper == null)
                    cookiesWrapper = new HttpCookieCollectionWrapper(Cookies);
                return cookiesWrapper;
            }
        }
    }

    public class HttpRequestWrapper : HttpRequestBase
    {
        private HttpRequest _httpRequest;
        public override System.Web.HttpBrowserCapabilitiesBase Browser
        {
            get
            {
                return new HttpBrowserCapabilitiesWrapper(this._httpRequest.Browser);
            }
        }
        public override NameValueCollection Params
        {
            get
            {
                return this._httpRequest.Params;
            }
        }
        public override string Path
        {
            get
            {
                return this._httpRequest.Path;
            }
        }
        public override string FilePath
        {
            get
            {
                return this._httpRequest.FilePath;
            }
        }
        public override NameValueCollection Headers
        {
            get
            {
                return this._httpRequest.Headers;
            }
        }
        public override NameValueCollection QueryString
        {
            get
            {
                return this._httpRequest.QueryString;
            }
        }
        public override string[] AcceptTypes
        {
            get
            {
                return this._httpRequest.AcceptTypes;
            }
        }
        public override string ApplicationPath
        {
            get
            {
                return this._httpRequest.ApplicationPath;
            }
        }
        public override string AnonymousID
        {
            get
            {
                return this._httpRequest.AnonymousID;
            }
        }
        public override string AppRelativeCurrentExecutionFilePath
        {
            get
            {
                return this._httpRequest.AppRelativeCurrentExecutionFilePath;
            }
        }
        public override HttpClientCertificate ClientCertificate
        {
            get
            {
                return this._httpRequest.ClientCertificate;
            }
        }
        public override Encoding ContentEncoding
        {
            get
            {
                return this._httpRequest.ContentEncoding;
            }
            set
            {
                this._httpRequest.ContentEncoding = value;
            }
        }
        public override int ContentLength
        {
            get
            {
                return this._httpRequest.ContentLength;
            }
        }
        public override string ContentType
        {
            get
            {
                return this._httpRequest.ContentType;
            }
            set
            {
                this._httpRequest.ContentType = value;
            }
        }
        public override HttpCookieCollection Cookies
        {
            get
            {
                return this._httpRequest.Cookies;
            }
        }
        public override string CurrentExecutionFilePath
        {
            get
            {
                return this._httpRequest.CurrentExecutionFilePath;
            }
        }
        public override System.Web.HttpFileCollectionBase Files
        {
            get
            {
                return new HttpFileCollectionWrapper(this._httpRequest.Files);
            }
        }
        public override Stream Filter
        {
            get
            {
                return this._httpRequest.Filter;
            }
            set
            {
                this._httpRequest.Filter = value;
            }
        }
        public override NameValueCollection Form
        {
            get
            {
                return this._httpRequest.Form;
            }
        }
        public override string HttpMethod
        {
            get
            {
                return this._httpRequest.HttpMethod;
            }
        }
        public override Stream InputStream
        {
            get
            {
                return this._httpRequest.InputStream;
            }
        }
        public override bool IsAuthenticated
        {
            get
            {
                return this._httpRequest.IsAuthenticated;
            }
        }
        public override bool IsLocal
        {
            get
            {
                return this._httpRequest.IsLocal;
            }
        }
        public override bool IsSecureConnection
        {
            get
            {
                return this._httpRequest.IsSecureConnection;
            }
        }
        public override WindowsIdentity LogonUserIdentity
        {
            get
            {
                return this._httpRequest.LogonUserIdentity;
            }
        }
        public override string PathInfo
        {
            get
            {
                return this._httpRequest.PathInfo;
            }
        }
        public override string PhysicalApplicationPath
        {
            get
            {
                return this._httpRequest.PhysicalApplicationPath;
            }
        }
        public override string PhysicalPath
        {
            get
            {
                return this._httpRequest.PhysicalPath;
            }
        }
        public override string RawUrl
        {
            get
            {
                return this._httpRequest.RawUrl;
            }
        }
        public override string RequestType
        {
            get
            {
                return this._httpRequest.RequestType;
            }
            set
            {
                this._httpRequest.RequestType = value;
            }
        }
        public override NameValueCollection ServerVariables
        {
            get
            {
                return this._httpRequest.ServerVariables;
            }
        }
        public override int TotalBytes
        {
            get
            {
                return this._httpRequest.TotalBytes;
            }
        }
        public override Uri Url
        {
            get
            {
                return this._httpRequest.Url;
            }
        }
        public override Uri UrlReferrer
        {
            get
            {
                return this._httpRequest.UrlReferrer;
            }
        }
        public override string UserAgent
        {
            get
            {
                return this._httpRequest.UserAgent;
            }
        }
        public override string[] UserLanguages
        {
            get
            {
                return this._httpRequest.UserLanguages;
            }
        }
        public override string UserHostAddress
        {
            get
            {
                return this._httpRequest.UserHostAddress;
            }
        }
        public override string UserHostName
        {
            get
            {
                return this._httpRequest.UserHostName;
            }
        }
        public override string this[string key]
        {
            get
            {
                return this._httpRequest[key];
            }
        }
        public HttpRequestWrapper(HttpRequest httpRequest)
        {
            if (httpRequest == null)
            {
                throw new ArgumentNullException("httpRequest");
            }
            this._httpRequest = httpRequest;
        }
        public override byte[] BinaryRead(int count)
        {
            return this._httpRequest.BinaryRead(count);
        }
        public override int[] MapImageCoordinates(string imageFieldName)
        {
            return this._httpRequest.MapImageCoordinates(imageFieldName);
        }
        public override string MapPath(string virtualPath)
        {
            return this._httpRequest.MapPath(virtualPath);
        }
        public override string MapPath(string virtualPath, string baseVirtualDir, bool allowCrossAppMapping)
        {
            return this._httpRequest.MapPath(virtualPath, baseVirtualDir, allowCrossAppMapping);
        }
        public override void ValidateInput()
        {
            this._httpRequest.ValidateInput();
        }
        public override void SaveAs(string filename, bool includeHeaders)
        {
            this._httpRequest.SaveAs(filename, includeHeaders);
        }
    }

    public abstract class HttpResponseBase : System.Web.HttpResponseBase, IHttpResponse
    {
        IHttpCachePolicy IHttpResponse.Cache
        {
            get
            {
                return Cache as IHttpCachePolicy;
            }
        }
        
        //TODO:
        //public virtual HttpCookieCollection Cookies
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
       
        //public virtual void AddCacheDependency(params CacheDependency[] dependencies)
        //{
        //    throw new NotImplementedException();
        //}
       
        //public virtual void AppendCookie(HttpCookie cookie)
        //{
        //    throw new NotImplementedException();
        //}
       
        //public virtual void SetCookie(HttpCookie cookie)
        //{
        //    throw new NotImplementedException();
        //}


        void IHttpResponse.AppendCookie(IHttpCookie cookie)
        {
            throw new NotImplementedException();
        }

        private IHttpCookieCollection cookiesWrapper;
        IHttpCookieCollection IHttpResponse.Cookies
        {
            get
            {
                if (cookiesWrapper == null)
                    cookiesWrapper = new HttpCookieCollectionWrapper(Cookies);
                return cookiesWrapper;
            }
        }

        void IHttpResponse.SetCookie(IHttpCookie cookie)
        {
            (this as IHttpResponse).Cookies.Set(cookie);
        }
    }

    class HttpCookieCollectionWrapper : IHttpCookieCollection
    {
        private HttpCookieCollection Items;
        public HttpCookieCollectionWrapper(HttpCookieCollection cookies)
        {
            Items = cookies;
        }

        public string[] AllKeys
        {
            get { return Items.AllKeys; }
        }

        public IHttpCookie this[string name]
        {
            get
            {
                return new HttpCookieWrapper(Items[name]);
            }
        }

        public void Add(IHttpCookie cookie)
        {
            var item = MapCookie(cookie);

            Items.Add(item);
        }

        private static HttpCookie MapCookie(IHttpCookie cookie)
        {
            var item = new HttpCookie(cookie.Name, cookie.Value);

            item.HttpOnly = cookie.HttpOnly;
            item.Domain = cookie.Domain;
            item.Expires = cookie.Expires;
            item.Path = cookie.Path;
            item.Secure = cookie.Secure;
            //item.Values.Clear();

            //foreach (var key in cookie.Values.AllKeys)
            //    item.Values.Add(key, cookie.Values[key]);
            return item;
        }

        public void Clear()
        {
            Items.Clear();
        }

        public IHttpCookie Get(string name)
        {
            return new HttpCookieWrapper(Items.Get(name));
        }

        public void Remove(string name)
        {
            Items.Remove(name);
        }

        public void Set(IHttpCookie cookie)
        {
            var item = MapCookie(cookie);
            Items.Set(item);
        }

        public IEnumerator<IHttpCookie> GetEnumerator()
        {
            var wrappers = new List<IHttpCookie>();
            foreach(HttpCookie item in Items)
                wrappers.Add(new HttpCookieWrapper(item));
            return wrappers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class HttpCookieWrapper : IHttpCookie
    {
        HttpCookie InnerCookie;
        public HttpCookieWrapper(HttpCookie cookie)
        {
            InnerCookie = cookie;
        }

        public string Domain
        {
            get
            {
                return InnerCookie.Domain;
            }
            set
            {
                InnerCookie.Domain = value;
            }
        }

        public DateTime Expires
        {
            get
            {
                return InnerCookie.Expires;
            }
            set
            {
                InnerCookie.Expires = value;
            }
        }

        public bool HasKeys
        {
            get { return InnerCookie.HasKeys; }
        }

        public bool HttpOnly
        {
            get
            {
                return InnerCookie.HttpOnly;
            }
            set
            {
                InnerCookie.HttpOnly = value;
            }
        }

        public string Name
        {
            get
            {
                return InnerCookie.Name;
            }
            set
            {
                InnerCookie.Name = value;
            }
        }

        public string Path
        {
            get
            {
                return InnerCookie.Path;
            }
            set
            {
                InnerCookie.Path = value;
            }
        }

        public bool Secure
        {
            get
            {
                return InnerCookie.Secure;
            }
            set
            {
                InnerCookie.Secure = value;
            }
        }

        public string Value
        {
            get
            {
                return InnerCookie.Value;
            }
            set
            {
                InnerCookie.Value = value;
            }
        }

        public NameValueCollection Values
        {
            get { return InnerCookie.Values; }
        }
         
        public string this[string key]
        {
            get
            {
                return InnerCookie[key];
            }
            set
            {
                InnerCookie[key]=value;
            }
        }
    }

    public class HttpResponseWrapper : HttpResponseBase
    {
        private HttpResponse _httpResponse;
        public override bool Buffer
        {
            get
            {
                return this._httpResponse.Buffer;
            }
            set
            {
                this._httpResponse.Buffer = value;
            }
        }
        public override bool BufferOutput
        {
            get
            {
                return this._httpResponse.BufferOutput;
            }
            set
            {
                this._httpResponse.BufferOutput = value;
            }
        }
        public override System.Web.HttpCachePolicyBase Cache
        {
            get
            {
                return new HttpCachePolicyWrapper(this._httpResponse.Cache);
            }
        }
        public override string CacheControl
        {
            get
            {
                return this._httpResponse.CacheControl;
            }
            set
            {
                this._httpResponse.CacheControl = value;
            }
        }
        public override string Charset
        {
            get
            {
                return this._httpResponse.Charset;
            }
            set
            {
                this._httpResponse.Charset = value;
            }
        }
        public override Encoding ContentEncoding
        {
            get
            {
                return this._httpResponse.ContentEncoding;
            }
            set
            {
                this._httpResponse.ContentEncoding = value;
            }
        }
        public override string ContentType
        {
            get
            {
                return this._httpResponse.ContentType;
            }
            set
            {
                this._httpResponse.ContentType = value;
            }
        }
        public override HttpCookieCollection Cookies
        {
            get
            {
                return this._httpResponse.Cookies;
            }
        }
        public override int Expires
        {
            get
            {
                return this._httpResponse.Expires;
            }
            set
            {
                this._httpResponse.Expires = value;
            }
        }
        public override DateTime ExpiresAbsolute
        {
            get
            {
                return this._httpResponse.ExpiresAbsolute;
            }
            set
            {
                this._httpResponse.ExpiresAbsolute = value;
            }
        }
        public override Stream Filter
        {
            get
            {
                return this._httpResponse.Filter;
            }
            set
            {
                this._httpResponse.Filter = value;
            }
        }
        public override NameValueCollection Headers
        {
            get
            {
                return this._httpResponse.Headers;
            }
        }
        public override Encoding HeaderEncoding
        {
            get
            {
                return this._httpResponse.HeaderEncoding;
            }
            set
            {
                this._httpResponse.HeaderEncoding = value;
            }
        }
        public override bool IsClientConnected
        {
            get
            {
                return this._httpResponse.IsClientConnected;
            }
        }
        public override bool IsRequestBeingRedirected
        {
            get
            {
                return this._httpResponse.IsRequestBeingRedirected;
            }
        }
        public override TextWriter Output
        {
            get
            {
                return this._httpResponse.Output;
            }
        }
        public override Stream OutputStream
        {
            get
            {
                return this._httpResponse.OutputStream;
            }
        }
        public override string RedirectLocation
        {
            get
            {
                return this._httpResponse.RedirectLocation;
            }
            set
            {
                this._httpResponse.RedirectLocation = value;
            }
        }
        public override string Status
        {
            get
            {
                return this._httpResponse.Status;
            }
            set
            {
                this._httpResponse.Status = value;
            }
        }
        public override int StatusCode
        {
            get
            {
                return this._httpResponse.StatusCode;
            }
            set
            {
                this._httpResponse.StatusCode = value;
            }
        }
        public override string StatusDescription
        {
            get
            {
                return this._httpResponse.StatusDescription;
            }
            set
            {
                this._httpResponse.StatusDescription = value;
            }
        }
        public override int SubStatusCode
        {
            get
            {
                return this._httpResponse.SubStatusCode;
            }
            set
            {
                this._httpResponse.SubStatusCode = value;
            }
        }
        public override bool SuppressContent
        {
            get
            {
                return this._httpResponse.SuppressContent;
            }
            set
            {
                this._httpResponse.SuppressContent = value;
            }
        }
        public override bool TrySkipIisCustomErrors
        {
            get
            {
                return this._httpResponse.TrySkipIisCustomErrors;
            }
            set
            {
                this._httpResponse.TrySkipIisCustomErrors = value;
            }
        }
        public HttpResponseWrapper(HttpResponse httpResponse)
        {
            if (httpResponse == null)
            {
                throw new ArgumentNullException("httpResponse");
            }
            this._httpResponse = httpResponse;
        }
        public override void AddCacheItemDependency(string cacheKey)
        {
            this._httpResponse.AddCacheItemDependency(cacheKey);
        }
        public override void AddCacheItemDependencies(ArrayList cacheKeys)
        {
            this._httpResponse.AddCacheItemDependencies(cacheKeys);
        }
        public override void AddCacheItemDependencies(string[] cacheKeys)
        {
            this._httpResponse.AddCacheItemDependencies(cacheKeys);
        }
        public override void AddCacheDependency(params CacheDependency[] dependencies)
        {
            this._httpResponse.AddCacheDependency(dependencies);
        }
        public override void AddFileDependency(string filename)
        {
            this._httpResponse.AddFileDependency(filename);
        }
        public override void AddFileDependencies(ArrayList filenames)
        {
            this._httpResponse.AddFileDependencies(filenames);
        }
        public override void AddFileDependencies(string[] filenames)
        {
            this._httpResponse.AddFileDependencies(filenames);
        }
        public override void AddHeader(string name, string value)
        {
            this._httpResponse.AddHeader(name, value);
        }
        public override void AppendCookie(HttpCookie cookie)
        {
            this._httpResponse.AppendCookie(cookie);
        }
        public override void AppendHeader(string name, string value)
        {
            this._httpResponse.AppendHeader(name, value);
        }
        public override void AppendToLog(string param)
        {
            this._httpResponse.AppendToLog(param);
        }
        public override string ApplyAppPathModifier(string virtualPath)
        {
            return this._httpResponse.ApplyAppPathModifier(virtualPath);
        }
        public override void BinaryWrite(byte[] buffer)
        {
            this._httpResponse.BinaryWrite(buffer);
        }
        public override void Clear()
        {
            this._httpResponse.Clear();
        }
        public override void ClearContent()
        {
            this._httpResponse.ClearContent();
        }
        public override void ClearHeaders()
        {
            this._httpResponse.ClearHeaders();
        }
        public override void Close()
        {
            this._httpResponse.Close();
        }
        public override void DisableKernelCache()
        {
            this._httpResponse.DisableKernelCache();
        }
        public override void End()
        {
            this._httpResponse.End();
        }
        public override void Flush()
        {
            this._httpResponse.Flush();
        }
        public override void Pics(string value)
        {
            this._httpResponse.Pics(value);
        }
        public override void Redirect(string url)
        {
            this._httpResponse.Redirect(url);
        }
        public override void Redirect(string url, bool endResponse)
        {
            this._httpResponse.Redirect(url, endResponse);
        }
        public override void RemoveOutputCacheItem(string path)
        {
            HttpResponse.RemoveOutputCacheItem(path);
        }
        public override void SetCookie(HttpCookie cookie)
        {
            this._httpResponse.SetCookie(cookie);
        }
        public override void TransmitFile(string filename)
        {
            this._httpResponse.TransmitFile(filename);
        }
        public override void TransmitFile(string filename, long offset, long length)
        {
            this._httpResponse.TransmitFile(filename, offset, length);
        }
        public override void Write(string s)
        {
            this._httpResponse.Write(s);
        }
        public override void Write(char ch)
        {
            this._httpResponse.Write(ch);
        }
        public override void Write(char[] buffer, int index, int count)
        {
            this._httpResponse.Write(buffer, index, count);
        }
        public override void Write(object obj)
        {
            this._httpResponse.Write(obj);
        }
        public override void WriteFile(string filename)
        {
            this._httpResponse.WriteFile(filename);
        }
        public override void WriteFile(string filename, bool readIntoMemory)
        {
            this._httpResponse.WriteFile(filename, readIntoMemory);
        }
        public override void WriteFile(string filename, long offset, long size)
        {
            this._httpResponse.WriteFile(filename, offset, size);
        }
        public override void WriteFile(IntPtr fileHandle, long offset, long size)
        {
            this._httpResponse.WriteFile(fileHandle, offset, size);
        }
        public override void WriteSubstitution(HttpResponseSubstitutionCallback callback)
        {
            this._httpResponse.WriteSubstitution(callback);
        }
    }

    public abstract class HttpServerUtilityBase : System.Web.HttpServerUtilityBase, IHttpServerUtility
    {
    }

    public class HttpServerUtilityWrapper : HttpServerUtilityBase
    {
        private HttpServerUtility _httpServerUtility;
        public override string MachineName
        {
            get
            {
                return this._httpServerUtility.MachineName;
            }
        }
        public override int ScriptTimeout
        {
            get
            {
                return this._httpServerUtility.ScriptTimeout;
            }
            set
            {
                this._httpServerUtility.ScriptTimeout = value;
            }
        }
        public HttpServerUtilityWrapper(HttpServerUtility httpServerUtility)
        {
            if (httpServerUtility == null)
            {
                throw new ArgumentNullException("httpServerUtility");
            }
            this._httpServerUtility = httpServerUtility;
        }
        public override Exception GetLastError()
        {
            return this._httpServerUtility.GetLastError();
        }
        public override void ClearError()
        {
            this._httpServerUtility.ClearError();
        }
        public override object CreateObject(string progID)
        {
            return this._httpServerUtility.CreateObject(progID);
        }
        public override object CreateObject(Type type)
        {
            return this._httpServerUtility.CreateObject(type);
        }
        public override object CreateObjectFromClsid(string clsid)
        {
            return this._httpServerUtility.CreateObjectFromClsid(clsid);
        }
        public override void Execute(string path)
        {
            this._httpServerUtility.Execute(path);
        }
        public override void Execute(string path, TextWriter writer)
        {
            this._httpServerUtility.Execute(path, writer);
        }
        public override void Execute(string path, bool preserveForm)
        {
            this._httpServerUtility.Execute(path, preserveForm);
        }
        public override void Execute(string path, TextWriter writer, bool preserveForm)
        {
            this._httpServerUtility.Execute(path, writer, preserveForm);
        }
        public override void Execute(IHttpHandler handler, TextWriter writer, bool preserveForm)
        {
            this._httpServerUtility.Execute(handler, writer, preserveForm);
        }
        public override string HtmlDecode(string s)
        {
            return this._httpServerUtility.HtmlDecode(s);
        }
        public override void HtmlDecode(string s, TextWriter output)
        {
            this._httpServerUtility.HtmlDecode(s, output);
        }
        public override string HtmlEncode(string s)
        {
            return this._httpServerUtility.HtmlEncode(s);
        }
        public override void HtmlEncode(string s, TextWriter output)
        {
            this._httpServerUtility.HtmlEncode(s, output);
        }
        public override string MapPath(string path)
        {
            return this._httpServerUtility.MapPath(path);
        }
        public override void Transfer(string path, bool preserveForm)
        {
            this._httpServerUtility.Transfer(path, preserveForm);
        }
        public override void Transfer(string path)
        {
            this._httpServerUtility.Transfer(path);
        }
        public override void Transfer(IHttpHandler handler, bool preserveForm)
        {
            this._httpServerUtility.Transfer(handler, preserveForm);
        }
        public override void TransferRequest(string path)
        {
            this._httpServerUtility.TransferRequest(path);
        }
        public override void TransferRequest(string path, bool preserveForm)
        {
            this._httpServerUtility.TransferRequest(path, preserveForm);
        }
        public override void TransferRequest(string path, bool preserveForm, string method, NameValueCollection headers)
        {
            this._httpServerUtility.TransferRequest(path, preserveForm, method, headers);
        }
        public override string UrlDecode(string s)
        {
            return this._httpServerUtility.UrlDecode(s);
        }
        public override void UrlDecode(string s, TextWriter output)
        {
            this._httpServerUtility.UrlDecode(s, output);
        }
        public override string UrlEncode(string s)
        {
            return this._httpServerUtility.UrlEncode(s);
        }
        public override void UrlEncode(string s, TextWriter output)
        {
            this._httpServerUtility.UrlEncode(s, output);
        }
        public override string UrlPathEncode(string s)
        {
            return this._httpServerUtility.UrlPathEncode(s);
        }
        public override byte[] UrlTokenDecode(string input)
        {
            return HttpServerUtility.UrlTokenDecode(input);
        }
        public override string UrlTokenEncode(byte[] input)
        {
            return HttpServerUtility.UrlTokenEncode(input);
        }
    }

    public abstract class HttpSessionStateBase : System.Web.HttpSessionStateBase, NLite.Net.IHttpSessionState
    {

        //IHttpSessionState IHttpSessionState.Contents
        //{
        //    get
        //    {
        //        return Contents as IHttpSessionState;
        //    }
        //}
        //TODO:
        //public virtual HttpCookieMode CookieMode
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
        
        //public virtual SessionStateMode Mode
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //IHttpStaticObjectsCollection IHttpSessionState.StaticObjects
        //{
        //    get
        //    {
        //        return StaticObjects as IHttpStaticObjectsCollection;
        //    }
        //}

        IEnumerable<string> NLite.Net.IHttpSessionState.Keys
        {
            get { return Keys.Cast<string>(); }
        }
    }

    public class HttpSessionStateWrapper : HttpSessionStateBase
    {
        private readonly HttpSessionState _session;
        public override int CodePage
        {
            get
            {
                return this._session.CodePage;
            }
            set
            {
                this._session.CodePage = value;
            }
        }
        public override System.Web.HttpSessionStateBase Contents
        {
            get
            {
                return this;
            }
        }
        public override HttpCookieMode CookieMode
        {
            get
            {
                return this._session.CookieMode;
            }
        }
        public override bool IsCookieless
        {
            get
            {
                return this._session.IsCookieless;
            }
        }
        public override bool IsNewSession
        {
            get
            {
                return this._session.IsNewSession;
            }
        }
        public override bool IsReadOnly
        {
            get
            {
                return this._session.IsReadOnly;
            }
        }
        public override NameObjectCollectionBase.KeysCollection Keys
        {
            get
            {
                return this._session.Keys;
            }
        }
        public override int LCID
        {
            get
            {
                return this._session.LCID;
            }
            set
            {
                this._session.LCID = value;
            }
        }
        public override SessionStateMode Mode
        {
            get
            {
                return this._session.Mode;
            }
        }
        public override string SessionID
        {
            get
            {
                return this._session.SessionID;
            }
        }
        public override System.Web.HttpStaticObjectsCollectionBase StaticObjects
        {
            get
            {
                return new HttpStaticObjectsCollectionWrapper(this._session.StaticObjects);
            }
        }
        public override int Timeout
        {
            get
            {
                return this._session.Timeout;
            }
            set
            {
                this._session.Timeout = value;
            }
        }
        public override object this[int index]
        {
            get
            {
                return this._session[index];
            }
            set
            {
                this._session[index] = value;
            }
        }
        public override object this[string name]
        {
            get
            {
                return this._session[name];
            }
            set
            {
                this._session[name] = value;
            }
        }
        public override int Count
        {
            get
            {
                return this._session.Count;
            }
        }
        public override bool IsSynchronized
        {
            get
            {
                return this._session.IsSynchronized;
            }
        }
        public override object SyncRoot
        {
            get
            {
                return this._session.SyncRoot;
            }
        }
        public HttpSessionStateWrapper(HttpSessionState httpSessionState)
        {
            if (httpSessionState == null)
            {
                throw new ArgumentNullException("httpSessionState");
            }
            this._session = httpSessionState;
        }
        public override void Abandon()
        {
            this._session.Abandon();
        }
        public override void Add(string name, object value)
        {
            this._session.Add(name, value);
        }
        public override void Clear()
        {
            this._session.Clear();
        }
        public override void Remove(string name)
        {
            this._session.Remove(name);
        }
        public override void RemoveAll()
        {
            this._session.RemoveAll();
        }
        public override void RemoveAt(int index)
        {
            this._session.RemoveAt(index);
        }
        public override void CopyTo(Array array, int index)
        {
            this._session.CopyTo(array, index);
        }
        public override IEnumerator GetEnumerator()
        {
            return this._session.GetEnumerator();
        }
    }

    public abstract class HttpContextBase : System.Web.HttpContextBase,IHttpContext
    {

        IHttpApplicationState IHttpContext.Application
        {
            get
            {
                return Application as IHttpApplicationState;
            }
        }

        IHttpRequest IHttpContext.Request
        {
            get
            {
                return Request as IHttpRequest;
            }
        }
        IHttpResponse IHttpContext.Response
        {
            get
            {
                return Response as IHttpResponse;
            }
        }
        IHttpServerUtility IHttpContext.Server
        {
            get
            {
                return Server as IHttpServerUtility;
            }
        }
        NLite.Net.IHttpSessionState IHttpContext.Session
        {
            get
            {
                return Session as NLite.Net.IHttpSessionState;
            }
        }


        Cache.ICache IHttpContext.Cache
        {
            get { return NLiteEnvironment.Cache; }
        }
    }

    public class HttpContextWrapper : HttpContextBase,IHttpContext
    {
        private readonly HttpContext _context;
        public override Exception[] AllErrors
        {
            get
            {
                return this._context.AllErrors;
            }
        }
        public override System.Web.HttpApplicationStateBase Application
        {
            get
            {
                return new HttpApplicationStateWrapper(this._context.Application);
            }
        }
        public override HttpApplication ApplicationInstance
        {
            get
            {
                return this._context.ApplicationInstance;
            }
            set
            {
                this._context.ApplicationInstance = value;
            }
        }
        public override System.Web.Caching.Cache Cache
        {
            get
            {
                return this._context.Cache;
            }
        }
        public override IHttpHandler CurrentHandler
        {
            get
            {
                return this._context.CurrentHandler;
            }
        }
        public override RequestNotification CurrentNotification
        {
            get
            {
                return this._context.CurrentNotification;
            }
        }
        public override Exception Error
        {
            get
            {
                return this._context.Error;
            }
        }
        public override IHttpHandler Handler
        {
            get
            {
                return this._context.Handler;
            }
            set
            {
                this._context.Handler = value;
            }
        }
        public override bool IsCustomErrorEnabled
        {
            get
            {
                return this._context.IsCustomErrorEnabled;
            }
        }
        public override bool IsDebuggingEnabled
        {
            get
            {
                return this._context.IsDebuggingEnabled;
            }
        }
        public override bool IsPostNotification
        {
            get
            {
                return this._context.IsDebuggingEnabled;
            }
        }
        public override IDictionary Items
        {
            get
            {
                return this._context.Items;
            }
        }
        public override IHttpHandler PreviousHandler
        {
            get
            {
                return this._context.PreviousHandler;
            }
        }
        public override ProfileBase Profile
        {
            get
            {
                return this._context.Profile;
            }
        }
        public override System.Web.HttpRequestBase Request
        {
            get
            {
                return new HttpRequestWrapper(this._context.Request);
            }
        }
        public override System.Web.HttpResponseBase Response
        {
            get
            {
                return new HttpResponseWrapper(this._context.Response);
            }
        }
        public override System.Web.HttpServerUtilityBase Server
        {
            get
            {
                return new HttpServerUtilityWrapper(this._context.Server);
            }
        }
        public override System.Web.HttpSessionStateBase Session
        {
            get
            {
                HttpSessionState session = this._context.Session;
                if (session == null)
                {
                    return null;
                }
                return new HttpSessionStateWrapper(session);
            }
        }
        public override bool SkipAuthorization
        {
            get
            {
                return this._context.SkipAuthorization;
            }
            set
            {
                this._context.SkipAuthorization = value;
            }
        }
        public override DateTime Timestamp
        {
            get
            {
                return this._context.Timestamp;
            }
        }
        public override TraceContext Trace
        {
            get
            {
                return this._context.Trace;
            }
        }
        public override IPrincipal User
        {
            get
            {
                return this._context.User;
            }
            set
            {
                this._context.User = value;
            }
        }
        public HttpContextWrapper(HttpContext httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }
            this._context = httpContext;
        }
        public override void AddError(Exception errorInfo)
        {
            this._context.AddError(errorInfo);
        }
        public override void ClearError()
        {
            this._context.ClearError();
        }
        public override object GetGlobalResourceObject(string classKey, string resourceKey)
        {
            return HttpContext.GetGlobalResourceObject(classKey, resourceKey);
        }
        public override object GetGlobalResourceObject(string classKey, string resourceKey, CultureInfo culture)
        {
            return HttpContext.GetGlobalResourceObject(classKey, resourceKey, culture);
        }
        public override object GetLocalResourceObject(string virtualPath, string resourceKey)
        {
            return HttpContext.GetLocalResourceObject(virtualPath, resourceKey);
        }
        public override object GetLocalResourceObject(string virtualPath, string resourceKey, CultureInfo culture)
        {
            return HttpContext.GetLocalResourceObject(virtualPath, resourceKey, culture);
        }
        public override object GetSection(string sectionName)
        {
            return this._context.GetSection(sectionName);
        }
        public override void RewritePath(string path)
        {
            this._context.RewritePath(path);
        }
        public override void RewritePath(string path, bool rebaseClientPath)
        {
            this._context.RewritePath(path, rebaseClientPath);
        }
        public override void RewritePath(string filePath, string pathInfo, string queryString)
        {
            this._context.RewritePath(filePath, pathInfo, queryString);
        }
        public override void RewritePath(string filePath, string pathInfo, string queryString, bool setClientFilePath)
        {
            this._context.RewritePath(filePath, pathInfo, queryString, setClientFilePath);
        }
        public override object GetService(Type serviceType)
        {
            return ((IServiceProvider)this._context).GetService(serviceType);
        }
    }
}

package md5e33f1f869378b77d97856a88381f946e;


public class DateTimeContinuousAxisLabelFormatter
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.telerik.android.common.Function
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_apply:(Ljava/lang/Object;)Ljava/lang/Object;:GetApply_Ljava_lang_Object_Handler:Com.Telerik.Android.Common.IFunctionInvoker, Telerik.Xamarin.Android.Common\n" +
			"";
		mono.android.Runtime.register ("Telerik.XamarinForms.ChartRenderer.Android.DateTimeContinuousAxisLabelFormatter, Telerik.XamarinForms.Chart, Version=2017.3.1123.240, Culture=neutral, PublicKeyToken=null", DateTimeContinuousAxisLabelFormatter.class, __md_methods);
	}


	public DateTimeContinuousAxisLabelFormatter ()
	{
		super ();
		if (getClass () == DateTimeContinuousAxisLabelFormatter.class)
			mono.android.TypeManager.Activate ("Telerik.XamarinForms.ChartRenderer.Android.DateTimeContinuousAxisLabelFormatter, Telerik.XamarinForms.Chart, Version=2017.3.1123.240, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public java.lang.Object apply (java.lang.Object p0)
	{
		return n_apply (p0);
	}

	private native java.lang.Object n_apply (java.lang.Object p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}

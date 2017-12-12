package md5594e48edf6f8d539e2dcd8d54f889365;


public class CalendarRenderer
	extends md596cddca0823a5f1145d7c54c21e6c186.AndroidRendererBase_2
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getSuggestedMinimumHeight:()I:GetGetSuggestedMinimumHeightHandler\n" +
			"n_getSuggestedMinimumWidth:()I:GetGetSuggestedMinimumWidthHandler\n" +
			"";
		mono.android.Runtime.register ("Telerik.XamarinForms.InputRenderer.Android.CalendarRenderer, Telerik.XamarinForms.Input, Version=2017.3.1123.240, Culture=neutral, PublicKeyToken=null", CalendarRenderer.class, __md_methods);
	}


	public CalendarRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == CalendarRenderer.class)
			mono.android.TypeManager.Activate ("Telerik.XamarinForms.InputRenderer.Android.CalendarRenderer, Telerik.XamarinForms.Input, Version=2017.3.1123.240, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public CalendarRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == CalendarRenderer.class)
			mono.android.TypeManager.Activate ("Telerik.XamarinForms.InputRenderer.Android.CalendarRenderer, Telerik.XamarinForms.Input, Version=2017.3.1123.240, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public CalendarRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == CalendarRenderer.class)
			mono.android.TypeManager.Activate ("Telerik.XamarinForms.InputRenderer.Android.CalendarRenderer, Telerik.XamarinForms.Input, Version=2017.3.1123.240, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public int getSuggestedMinimumHeight ()
	{
		return n_getSuggestedMinimumHeight ();
	}

	private native int n_getSuggestedMinimumHeight ();


	public int getSuggestedMinimumWidth ()
	{
		return n_getSuggestedMinimumWidth ();
	}

	private native int n_getSuggestedMinimumWidth ();

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

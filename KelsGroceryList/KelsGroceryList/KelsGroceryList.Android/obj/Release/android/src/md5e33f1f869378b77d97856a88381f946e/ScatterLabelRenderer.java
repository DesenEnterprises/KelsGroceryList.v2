package md5e33f1f869378b77d97856a88381f946e;


public class ScatterLabelRenderer
	extends com.telerik.widget.chart.visualization.cartesianChart.series.scatter.ScatterSeriesLabelRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getLabelText:(Lcom/telerik/widget/chart/engine/dataPoints/DataPoint;)Ljava/lang/String;:GetGetLabelText_Lcom_telerik_widget_chart_engine_dataPoints_DataPoint_Handler\n" +
			"";
		mono.android.Runtime.register ("Telerik.XamarinForms.ChartRenderer.Android.ScatterLabelRenderer, Telerik.XamarinForms.Chart, Version=2017.3.1123.240, Culture=neutral, PublicKeyToken=null", ScatterLabelRenderer.class, __md_methods);
	}


	public ScatterLabelRenderer (com.telerik.widget.chart.visualization.common.ChartSeries p0)
	{
		super (p0);
		if (getClass () == ScatterLabelRenderer.class)
			mono.android.TypeManager.Activate ("Telerik.XamarinForms.ChartRenderer.Android.ScatterLabelRenderer, Telerik.XamarinForms.Chart, Version=2017.3.1123.240, Culture=neutral, PublicKeyToken=null", "Com.Telerik.Widget.Chart.Visualization.Common.ChartSeries, Telerik.Xamarin.Android.Chart, Version=2017.3.1123.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}


	public java.lang.String getLabelText (com.telerik.widget.chart.engine.dataPoints.DataPoint p0)
	{
		return n_getLabelText (p0);
	}

	private native java.lang.String n_getLabelText (com.telerik.widget.chart.engine.dataPoints.DataPoint p0);

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
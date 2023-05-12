$(document).ready(function () {
	 $(function ($) {
	  $('#map-turkey').cssMap({
		  'size': 660,
		  'tooltips': 'floating',
		  'onClick': function (e) {
			  var link = e.children('a').attr('href'),
			  text = e.children('a').eq(0).text();
			  var sehir=text;			  
			  $(".merkez-adres").hide();
			  $(".lutfen").hide();
			  $("div[rel="+link.replace("#","")+"]").show();
		  }
	  });
  });
});
$(document).ready(function(){
	$("li.nav-btn").click(function(){
		$("ul.menu").slideToggle();
	});

	// Fix Danh Muc in the left 
	$(window).resize(function(){
		if ($(window).width() > 768){
			$('ul.menu').removeAttr('style');
		}
	});

	// Toggle DANH MUC button 
	$('.toggle-button').on('click', function(){
		$('.sidebar').toggleClass('abrir');
	});

	// add fix-top navbar and remove it when you scroll. 
	$(window).scroll(function(event){
    	$('.main-nav').addClass('navbar-fixed-top');
    	if ($(this).scrollTop() == 0) {
    		$('.main-nav').removeClass('navbar-fixed-top');
    	}
    });
});

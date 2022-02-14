
/*
onload = function() {
  // Peso
  document.getElementById('weight_in').onchange = function() {
      document.getElementById('peso_out').innerHTML = this.value + " kg.";
  };
  document.getElementById('weight_in').onchange();

  // Dimensiones
  ////////////////////////////////////////// ancho
  document.getElementById('width_in').onchange = function() {
      document.getElementById('ancho_out').innerHTML = this.value + " cm.";
  };
  document.getElementById('width_in').onchange();

  ////////////////////////////////////////// largo
  document.getElementById('length_in').onchange = function() {
      document.getElementById('largo_out').innerHTML = this.value + " cm.";
  };
  document.getElementById('length_in').onchange();

  ////////////////////////////////////////// fondo
  document.getElementById('depth_in').onchange = function() {
      document.getElementById('fondo_out').innerHTML = this.value + " cm.";
  };
  document.getElementById('depth_in').onchange();
};

var price = 1000;
*/

(function($){
	$.expr[':'].external = function(obj){
		return !obj.href.match(/^mailto\:/) &&
		( obj.hostname && (obj.hostname != location.hostname) ) &&
		$(obj).find('img').length == 0 &&
		$(obj).hasClass('banner') == false;
	};
	/* Av heights */
	$.fn.av_heights = function(){
		tallest = 0;
		$(this).each(function(){
			$(this).css({ 'height': 'auto' });
			if ( $(this).outerHeight() > tallest ) { tallest = $(this).outerHeight(); };
		})
		$(this).css({'height': tallest});
	}
	/* Toggle Element */
	$.fn.toggleElement = function(){
		$(this).live( 'click', function(){
			if( $(this).hasClass('fadeToggle') )
				$(this.hash).fadeToggle();
			else if( $(this).hasClass('slideToggle') )
				$(this.hash).slideToggle();
			else
				$(this.hash).toggle();
			$(this).toggleClass( 'toggle-' + this.hash.replace('#','') );
			$(this).toggleClass( 'toggle-active' );
			return false;
		});
	}
	/* Toggle Content */
	$.fn.toggleContent = function(options){
        var obj = $(this);
        var settings = $.extend({
          'type'            : 'slide'
        }, options);
        obj.each(function() {
         $(this).bind('click',function(event) {
             var open = $(this);
             var target = (open.attr('href'))?         open.attr('href'):open.data('target');
             // event.preventDefault();
            if (settings.type == 'slide') {
                $(target).slideToggle();
            } else if (settings.type == 'normal') {
                $(target).toggle();
            } else {
                $(settings.content).toggle();
            }
            obj.trigger('afterOpen', [settings.type, obj]);
        });
      });
    };
    /* */
})(jQuery);


jQuery(document).ready( function($){
	// Resize End	
	$(window).resize(function(){
		if( this.resizeTO ) clearTimeout(this.resizeTO);
		this.resizeTO = setTimeout(function(){
			$(this).trigger('resizeEnd');
		}, 100);
	});
	// Carousel
	$('.crsl-items').carousel({autoRotate:5000});
	// Equal Heights
	$('.equal-heights').find('.equal-height-item').av_heights();
	// Toggle
	$('.toggle').slideToggle({});
	// click menu responsive
  //
  //$('.sidebar-block').sticky('#main');
  //
	$('#nav-responsive').click( function(){
		$('#menu-responsive').slideToggle();
	});

	// Script CXP
	// $('#price').html(price);  // inicializa el precio

     $('.control').toggleContent(); // comportamiento genérico para manipular visibilidad

    // Color Value

    // Close Shipping
    $('.btn-close').click( function(){
    	$('#multienvio').slideUp('slow');
    });

    $('.alert-close').click( function(){
    	$('#alert').slideUp('slow');
    });

    // editar cuenta de usuario
    $('.control-account').toggleContent();
    $('.control-account').bind('afterOpen',function(type,obj){
      $('#account-details').slideUp();
    });

    $('.control-save-account').toggleContent();
    $('.control-save-account').bind('afterOpen',function(type,obj){
      $('#account-edit').slideUp();
    });

    // agregar nuevo email
    $('.control-new-email').toggleContent();
    $('.control-new-email').bind('afterOpen',function(type,obj){
      $('#add-new-email-button').slideUp();
    });

    $('.control-verify').toggleContent();
    $('.control-verify').bind('afterOpen',function(type,obj){
      $('#add-new-email').slideUp();
    });
});
;(function($){

	$.expr[':'].external = function(obj){
		return !obj.href.match(/^mailto\:/) &&
		( obj.hostname && (obj.hostname != location.hostname) ) &&
		$(obj).find('img').length == 0 &&
		$(obj).hasClass('banner') == false;
	};
/**
 * ---------------------------------------------------------------------
 * Av Heights
 * ---------------------------------------------------------------------
 **/
	$.fn.heights = function(args){
		var defaults = {
			itemClass : 'equal-height-item'
		};
		return $(this).each( function(){
			var obj = this;
			// Extend
			if( $.isEmptyObject(args) === false )
				$.extend( defaults, args );

			obj.init = function(defaults, obj){
				tallest = 0;
				$(obj).find('.'+defaults.itemClass).each(function(){
					$(this).css({ 'height': 'auto' });
					if ( $(this).outerHeight() > tallest )
						tallest = $(this).outerHeight();
				});
				$(obj).find('.'+defaults.itemClass).css({'height': tallest});
			};

			// Default Initialization
			obj.init(defaults, obj);

			// initilice with $(window) resize (resizeEnd)
			$(window).load( function(){
				obj.init(defaults, obj);
			});

			// initilice with $(window) resize (resizeEnd)
			$(window).on( 'resizeEnd', function(){
				obj.init(defaults, obj);
			});
		});
	};

/**
 * ---------------------------------------------------------------------
 * Toggle Elements
 * ---------------------------------------------------------------------
 **/
	$.fn.toggleElement = function(){
		$(this).on( 'click', function(){
			var obj = this;
			// Toggle
			if( $(obj).hasClass('fadeToggle') ){
				$(obj.hash).fadeToggle();
			} else if( $(obj).hasClass('slideToggle') ){
				$(obj.hash).slideToggle();
			} else{
				$(obj.hash).toggle();
			}
			// Helper Actives
			$(this).toggleClass( 'toggle-' + this.hash.replace('#','') );
			$(this.hash).toggleClass('toggle-target-active');
			$(this).toggleClass( 'toggle-active' );
			// Trigger
			$(obj).trigger('toggleElement', [obj]);
			return false;
		});
	};
	$.fn.effect = function(effect){
		return $(this).each( function(){
			if( effect == 'show' ) $(this).show();
			if( effect == 'hide' ) $(this).hide();
			if( effect == 'fadeIn' ) $(this).fadeIn();
			if( effect == 'fadeOut' ) $(this).fadeOut();
		});
	};

/**
 * ---------------------------------------------------------------------
 * Toggle Content
 * ---------------------------------------------------------------------
 **/
	$.fn.toggleContent = function(options){
		var obj = $(this);
		var settings = $.extend({
			'type' : 'slide'
		}, options);
		obj.each(function() {
			$(this).bind('click',function(event) {
				var open = $(this);
				var target = ( open.attr('href') ) ? open.attr('href') : open.data('target');
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
})(jQuery);

var box;
var cxp = {
	triggerScripts : {
		init : function(){
			cxp.carousel.init();
			cxp.heights.init();
		}
	},
	carousel : {
		init : function(){
			// Carousel
			if( $('.crsl-items').length > 0 )
				$('.crsl-items').carousel({ autoRotate : 5000 });
		}
	},
	heights : {
		init : function(){
			// Equal Heights
			$('.equal-heights').find('.equal-height-item').heights();
		}
	},
	toggleContent : {
		init : function(target, context){
			// comportamiento genérico para manipular visibilidad
			$('.control').toggleContent();
			$('.control-account').toggleContent();
			$('.control-save-account').toggleContent();
			$('.control-new-email').toggleContent();
			$('.control-verify').toggleContent();
		}
	},
	afterOpen : {
		init : function(){
			// editar cuenta de usuario
			$('.control-account').bind('afterOpen',function(type,obj){
				$('#account-details').slideUp();
			});
			$('.control-save-account').bind('afterOpen',function(type,obj){
				$('#account-edit').slideUp();
			});
			$('.control-new-email').bind('afterOpen',function(type,obj){
				$('#add-new-email-button').slideUp();
			});
			$('.control-verify').bind('afterOpen',function(type,obj){
				$('#add-new-email').slideUp();
			});
		}
	},
	effects : {
		init : function(){
			// Toggle
			$('.toggle').slideToggle({});

			// click menu responsive
			$('#nav-responsive').click( function(){
				$('#menu-responsive').slideToggle();
			});

			// Close Shipping
			$('.btn-close').click( function(){
				$('#multienvio').slideUp('slow');
			});

			$('.alert-close').click( function(){
				$('#alert').slideUp('slow');
			});
		}
	},
	box : {
		init : function(){
			if( $('#cxpbox').length === 0 )
				return false;

			cxp.box.instance();

			// Instance
			$('#cxpbox').append( $('#boxCanvas').show() );

			// Get Dimensions
			width = $('#width').val();
			length = $('#length').val();
			height = $('#height').val();
			$(":range").rangeinput();

			// Bind events
			$("#width").on("change", function(){
				var val = 0;
				val = parseInt($('#width').val(),10) - parseInt(width,10);
				box.boxWidthAdd(val);
				width = parseInt($('#width').val(),10);
			});
			$("#height").on("change", function(data){
				var val = 0;
				val = parseInt($('#height').val(),10) - parseInt(height,10);
				box.boxHeightAdd(val);
				height = parseInt($('#height').val(),10);
			});
			$("#length").on("change", function(data){
				var val = 0;
				val = parseInt($('#length').val(),10) - parseInt(length,10);
				box.boxLengthAdd(val);
				length = parseInt($('#length').val(),10);

			});
		},
		instance : function(){
			var bound = false;
			box = Processing.getInstanceById('boxCanvas');
			if( box !== null )
				bound = true;
			if( !bound )
				setTimeout(cxp.box.instance, 250);
		}
	}
};
var helperEnvio = {
	mostrarFichaRemitente : function(){
		// Validacion para mostrar ficha remitente
		if( $('#dataRemitenteDireccion').text() !== '' || $('#dataRemitenteNombre').text() !== '' )
			$('#dataRemitente').show();
		else
			$('#dataRemitente').hide();
	},
	mostrarFichaDestinatario : function(){
		// Validacion para mostrar ficha remitente
		if( $('#dataDestinatarioDireccion').text() !== '' || $('#dataDestinatarioNombre').text() !== '' )
			$('#dataDestinatario').show();
		else
			$('#dataDestinatario').hide();
	}
};

jQuery(document).ready( function($){
	// Resize End
	$(window).resize(function(){
		if( this.resizeTO ) clearTimeout(this.resizeTO);
		this.resizeTO = setTimeout(function(){
			$(this).trigger('resizeEnd');
		}, 100);
	});

/*-------------------------------------- Carousel */
	cxp.carousel.init();

/*-------------------------------------- Heights */
	cxp.heights.init();

/*-------------------------------------- toggleContent */
	cxp.toggleContent.init();

/*-------------------------------------- triggrAfterOpen */
	cxp.afterOpen.init();

/*-------------------------------------- effects */
	cxp.effects.init();

/*-------------------------------------- boxDimensions */
	$('#boxCanvas').hide();

/*-------------------------------------- Bind Actions */
	// envioOnline.init('#features');
	// envioOnline.init('#main');

	// Ajax URL
	var ajaxURL = '.',
		nuevoEnvio = null,
		nuevoRemitente = new Remitente,
		nuevoDestinatario = null;

	// Crear Envío
	$('#features').on('click', '.crearEnvioOnline', function(event){
		// Prevent hash url
		event.preventDefault();

		// Create the respective object
		switch ( $(this).data('tipo') ){
			case 'encomienda':
				nuevoEnvio = new EnvioEncomienda(0);
				nuevoDestinatario = new DestinatarioNacional;
				break;
			case 'sobre':
				nuevoEnvio = new EnvioSobre(0);
				nuevoDestinatario = new DestinatarioNacional;
				break;
			case 'giro':
				nuevoEnvio = new EnvioGiro(0);
				break;
		}

		// Get content
		var url = this.hash.replace('#!/', '');
		$.get( ajaxURL+'/data/'+url, {}, function(data){
			if( $('#features').length > 0 )
				$('#features').remove();

			if( $('#main').hasClass('hide') )
				$('#main').removeClass('hide');

			if( $('#main').hasClass('black-background') === false )
				$('#main').addClass('black-background');

			$('#main').html(data);

			// actualizar precio
			$('#precioEnvioOnline').find('span.cost').text( '$'+ nuevoEnvio.getPrecio() +'.-' );
		});
		return false;
	});

	// Buscar Dirección
	$('#main').on('submit', '#buscarDireccion', function(event){
		// Prevenir envío de formulario y recarga de página
		event.preventDefault();

		// Obtener información del objeto y configurar parámetros
		data = $(this).serializeArray();
		var direccionRemitente = $('#direccionRemitente').val();

		// Validacion mínima de presencia de dirección
		if( direccionRemitente == '' || direccionRemitente.length < 3 )
			return false;

		// En este módulo debería validare la dirección y
		// generar los errores o el mapa respectivamente
		$.get( ajaxURL+'/data/mapa-remitente.html', {}, function(data){
			if( $('.air-data').length > 0 )
				$('.air-data').remove();
			// Mostrar mapa
			$('#mapaRemitente').show().html(data);

			// El mapa debe traer la información estandarizada de la Dirección
			var DireccionRemitente = new Direccion;
			var direccion_remitente_data = $('#mapaDireccionRemitente').data('direccion');
			DireccionRemitente.construirDireccion( direccion_remitente_data );

			// Mostrar Caja Datos Remitente
			$('#dataRemitente').find('#dataRemitenteDireccion').text( DireccionRemitente.direccion_estandarizada );
			$('#dataRemitente').show();

			// Copiar la dirección estandarizada breve al campo
			$('#direccionRemitente').val( DireccionRemitente.direccion_estandarizada );

			nuevoRemitente.setDireccion( DireccionRemitente );
		});
		return false;
	});

	// Validar campos remitente
	$('#main').on('keyup', '.campoRemitente', function(){
		var remitenteCompleto = true;
		$('#main').find('.campoRemitente').each( function(){
			// Validar cada dato del remitente
			// Se deben añadir validaciones On-the-fly de los valores
			// Por ejemplo: email - rut
			if( this.value === '' )
				remitenteCompleto = false;
		});

		if( $(this).attr('name') == 'nombreRemitente' )
			$('#dataRemitente').find('#dataRemitenteNombre').text( $(this).val() );

		// Detectar y mostrar dataRemitente
		helperEnvio.mostrarFichaRemitente();

		if( remitenteCompleto === true )
			$('#crearRemitente').removeClass('btn-disabled');
		else
			$('#crearRemitente').addClass('btn-disabled');
	});

	// Crear Remitente
	$('#main').on('click', '#crearRemitente', function(event){
		// Prevent hash url
		event.preventDefault();

		if ( $(this).hasClass('btn-disabled') )
			return false;

		nuevoRemitente
			.setNombre( $('input[name="nombreRemitente"]').val() )
			.setEmail( $('input[name="emailRemitente"]').val() )
			.setRut( $('input[name="rutRemitente"]').val() );

		// Get content
		type = this.hash.replace('#!/', '');
		$.get( ajaxURL+'/data/'+type, {}, function(data){
			var actualizarPrecio = function( precio ){
				$('#precioEnvioOnline').find('span.cost').text('$'+ precio +'.-');
			}

			// Cargar HTML
			$('#main').html(data);
			// Bind effects
			cxp.triggerScripts.init();
			cxp.box.init();

			// actualizar info del remitente
			$('#banner-remitente-fn').text( nuevoRemitente.nombre );
			$('#banner-remitente-addr').text( nuevoRemitente.direccion.direccion_estandarizada );

			// setear dimensiones de acuerdo a los valores iniciales de los sliders
			if( type === 'encomienda.html' ){
				nuevoEnvio.setPeso( $('#peso').val() );
				nuevoEnvio.setAlto( $('#height').val() );
				nuevoEnvio.setAncho( $('#width').val() );
				nuevoEnvio.setLargo( $('#height').val() );
				actualizarPrecio( nuevoEnvio.getPrecio() );

				$('#peso').on('change', function(){
					nuevoEnvio.setPeso( $(this).val() );
					$('#object-peso').text( $(this).val() );
					actualizarPrecio( nuevoEnvio.getPrecio() );
				});
				$('#height').on('change', function(){
					nuevoEnvio.setAlto( $(this).val() );
					$('#object-height').text( $(this).val() );
					actualizarPrecio( nuevoEnvio.getPrecio() );
				});
				$('#width').on('change', function(){
					nuevoEnvio.setAncho( $(this).val() );
					$('#object-width').text( $(this).val() );
					actualizarPrecio( nuevoEnvio.getPrecio() );
				});
				$('#height').on('change', function(){
					nuevoEnvio.setLargo( $(this).val() );
					$('#object-height').text( $(this).val() );
					actualizarPrecio( nuevoEnvio.getPrecio() );
				});
			}
		});
		return false;
	});

	// Crear Paquete
	$('#main').on('click', '.enviarEncomienda', function(event){
		event.preventDefault();
		// Get content
		var url = this.hash.replace('#!/', '');
		$.get( ajaxURL+'/data/'+url, {}, function(data){
			$('#main').html(data);

			// actualizar info del remitente
			$('#banner-remitente-fn').text( nuevoRemitente.nombre );
			$('#banner-remitente-addr').text( nuevoRemitente.direccion.direccion_estandarizada );

			if( url === 'encomienda.html' ){
				// actualizar info de la encomienda
				$('#banner-encomienda-peso').text( nuevoEnvio.peso / 1000 );
				$('#banner-encomienda-ancho').text( nuevoEnvio.width );
				$('#banner-encomienda-largo').text( nuevoEnvio.length );
				$('#banner-encomienda-height').text( nuevoEnvio.height );
			}

			// actualizar precio
			$('#precioEnvioOnline').find('span.cost').text( '$'+ nuevoEnvio.getPrecio() +'.-' );
		});
		return false;
	});
	// Buscar Dirección - Obtiene opciones
	$('#main').on('click submit', '.buscarDireccion', function(){

	});
	// Enviar Dirección para obtener precio
	$('#main').on('click', '.enviarDireccionPrecio', function(){

	});

	// Validar campos destinatario
	$('#main').on('keyup', '.campoDestinatario', function(){
		var destinatarioCompleto = true;
		$('#main').find('.campoDestinatario').each( function(){
			// Validar cada dato del remitente
			// Se deben añadir validaciones On-the-fly de los valores
			// Por ejemplo: email - rut
			if( this.value === '' )
				destinatarioCompleto = false;
		});

		if( $(this).attr('name') == 'nombreDestinatario' )
			$('#dataDestinatario').find('#dataDestinatarioNombre').text( $(this).val() );

		// Detectar y mostrar dataRemitente
		helperEnvio.mostrarFichaDestinatario();

		if( destinatarioCompleto === true )
			$('#crearDestinatario').removeClass('btn-disabled');
		else
			$('#crearDestinatario').addClass('btn-disabled');
	});

	// Crear Destinatario
	$('#main').on('click', '#crearDestinatario', function( event ){
		event.preventDefault();

		nuevoDestinatario.
			setNombre( $('input[name="nombreDestinatario"]').val() ).
			setEmail( $('input[name="emailDestinatario"]').val() ).
			setTelefono( $('input[name="telefonoDestinatario"]') );

		var DireccionDestinatario = new Direccion;
		var direccion_destinatario_data = $('#mapaDireccionDestinatario').data('direccion');
		DireccionDestinatario.construirDireccion( direccion_destinatario_data );

		nuevoDestinatario.setDireccion( DireccionDestinatario );

		// Get content
		var url = this.hash.replace('#!/', '');
		$.get( ajaxURL+'/data/'+url, {}, function(data){
			$('#main').html(data);

			// actualizar info del remitente
			$('#banner-remitente-fn').text( nuevoRemitente.nombre );
			$('#banner-remitente-addr').text( nuevoRemitente.direccion.direccion_estandarizada );

			// actualizar info de la encomienda
			$('#banner-encomienda-peso').text( nuevoEnvio.peso / 1000 );
			$('#banner-encomienda-ancho').text( nuevoEnvio.width );
			$('#banner-encomienda-largo').text( nuevoEnvio.length );
			$('#banner-encomienda-height').text( nuevoEnvio.height );

			// actualizar info de destinatario
			$('#banner-destinatario-fn').text( nuevoDestinatario.nombre );
			$('#banner-destinatario-addr').text( nuevoDestinatario.direccion.direccion_estandarizada );
		});
		return false;
	});

	// Enviar Fecha de retiro
	$('#main').on('click', '.enviarFechaRetiro', function(){
		event.preventDefault();
		return false;
	});
	// Enviar Fecha de entrega
	$('#main').on('click', '.enviarFechaEntrega', function(){

	});
	// Enviar Objeto de Envío
	$('#main').on('click', '.enviarEnvioOnline', function(){

	});
	// Enviar Datos de Facturación
	$('#main').on('click submit', '.enviaDatosFacturacion', function(){

	});

});
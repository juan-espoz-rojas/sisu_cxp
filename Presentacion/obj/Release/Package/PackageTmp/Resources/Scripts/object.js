/**
 * Controladores de objetos del proceso de Envíos CXP
 *
 * Convenciones de nombres utilizadas:
 * ===================================
 * * Nombres de clases con StudlyCaps
 * * Nombres de métodos con camelCase
 * * Nombres de variables:
 *   * Si deben corresponder a determinados tipos de objetos, mantienen el nombre de la clase a la que corresponden
 *   * Para otras variables, utilizar snake_case
 */

/**
 * Conjunto de envios asociados a la compra
 * @type {Object}
 */
var Paquetes = {
	lista : [],
	precio: 0,
	agregarEnvio : function( Envio ){
		var paquete = {
			tipo: Envio.getTipo(),
			dimensiones: {
				ancho: Envio.getAncho(),
				largo: Envio.getLargo(),
				alto : Envio.getAlto(),
				peso : Envio.getPeso()
			},
			precio: Envio.getPrecio()
		};
		this.lista.push( paquete );
		this.precio += paquete.precio;
		return this;
	},
	contar : function(){
		return this.lista.length;
	},
	cotizar: function(){
		return this.precio;
	}
}


/**
 * Clase modelo para restantes tipos de envío
 * @return {[type]} [description]
 */
var Envio = function( id ){
	this.id = id || Paquetes.contar();
	this.alto  = 0;
	this.ancho = 0;
	this.largo = 0;
	this.peso  = 0;

	var dimensiones = ['alto', 'ancho', 'largo', 'peso'];

	/**
	 * Precio base para un envío.
	 * Sólo para propósitos de simulación.
	 * Los tipos derivados de Envio (p.ej; EnvioEncomienda) pueden redefinir este valor según corresponda
	 * @type {Number}
	 */
	this.precio_base = 1000;

	/**
	 * Ponderación de medidas para cálculo de precio.
	 * Sólo se utiliza para propósitos de simulación.
	 * Los tipos derivados pueden redefinir estos factores.
	 * @type {Object}
	 */
	this.factores_precio = {
		ancho: 0.3,
		largo: 0.3,
		alto : 0.3,
		peso : 0.5
	}
	this.getTipo = function(){
		return this.tipo;
	}
	this.getId = function(){
		return this.id;
	}
	this.getAlto = function(){
		return this.alto;
	}
	this.getLargo = function(){
		return this.largo;
	}
	this.getAncho = function(){
		return this.ancho;
	}
	this.getPeso = function(){
		return this.peso;
	}

	/**
	 * Simulación de cálculo de Precio.
	 * Fórmula se utiliza solamente con fines ilustrativos del proceso de interacción
	 * @return {Number} Precio
	 */
	this.getPrecio = function(){
		var precio = this.precio_base;
		for ( var d in dimensiones ) {
			precio += this.factores_precio[dimensiones[d]] * this[dimensiones[d]];
		}
		return Math.floor( precio );
	}
}

var EnvioEncomienda = function( id ){
	Envio.call( this, id );
	var max  = {
		ancho : 100,
		alto  : 100,
		largo : 100,
		peso  : 50000
	}
	this.tipo  = 'encomienda';
	this.precio_base = 2000;
	this.ancho = 0;
	this.largo = 0;
	this.alto  = 0;
	this.peso  = 0;
	this.setAncho = function( cms ){
		var ancho  = parseInt( cms, 10 );
		if ( ancho <= max.ancho ) {
			this.ancho = ancho;
			return this;
		} else {
			this.ancho = max.ancho;
			return false;
		}
	}
	this.setLargo = function( cms ){
		var largo = parseInt( cms, 10 );
		if ( largo <= max.largo ) {
			this.largo = largo;
			return this;
		} else {
			this.largo = max.largo;
			return false;
		}
	}
	this.setAlto =  function( cms ){
		var alto = parseInt( cms, 10 );
		if ( alto <= max.alto ) {
			this.alto = alto;
			return this;
		} else {
			this.alto = max.alto;
			return false;
		}
	}
	this.setPeso = function( medida, unidad ){
		var unidad = unidad || 'kg';
		var medida = parseInt( medida, 10 );
		switch( unidad ){
			case 'kg':
				// transformar de kilo a gramos
				medida = medida * 1000;
				break;
			case 'g':
			default:
				medida = medida;
				break;
		}
		if ( medida <= max.peso ) {
			this.peso = medida;
			return this;
		} else {
			this.peso = max.peso;
			return false;
		}
	}
}
EnvioEncomienda.prototype = new Envio();

var EnvioSobre = function( id ){
	Envio.call( this, id );
	this.tipo  = 'sobre';

	/**
	 * Sólo a modo de ejemplo: caso en que dimensiones no influyen directamente en el precio
	 * @type {Object}
	 */
	this.factores_precio = {
		alto : 0,
		ancho: 0,
		largo: 0,
		peso : 0
	}
	this.alto  = 2;
	this.ancho = 22;
	this.largo = 33;
	this.peso  = 1500;
}
EnvioSobre.prototype = new Envio();

var EnvioGiro = function( id ){
	var monto = 0;
}

var Remitente = function(){
	this.direccion = null;
	this.nombre = '';
	this.email = '';
	this.rut = '';
	this.setDireccion = function( Direccion ){
		this.direccion = Direccion;
		return this;
	}
	this.setNombre = function( nombre ){
		// poner en mayúsculas primera letra de cada palabra
		var partes = nombre.split(' '),
			partes_nombre = [];
		for ( var i = 0, q = partes.length; i < q; i++ ){
			partes_nombre[ i ] = partes[ i ].charAt(0).toUpperCase() + partes[ i ].substr( 1 );
		}
		this.nombre = partes_nombre.join(' ');
		return this;
	}
	this.setEmail = function( correo ){
		if ( validarEmail(correo) ){
			this.email = correo;
		}
		return this;
	}
	this.setRut = function( rut_input ){
		if ( validarRut( rut_input) ) {
			this.rut = rut_input;
		}
		return this;
	}
}

/**
 * Validar RUT
 * @param  {string} rut RUT ingresado por el usuario. Puede o no tener puntos, DEBE tener el dígito identificador separado por guión
 * @return {bool} Verdadero si es RUT válido
 * @internal Original: http://snipplr.com/view/57237/
 */
var validarRut = function( rut ){
	var rut = rut.replace(/[.]/g, rut);
	if ( rut.length < 9 )
   		return false;
	var i1   = rut.indexOf("-");
	var dv   = rut.substr(i1+1);
	var dv   = dv.toUpperCase();
	var nu   = rut.substr(0,i1);
	var cnt  = 0;
	var suma = 0;
	for ( var i  = nu.length-1; i>=0; i--){
		var dig  = nu.substr(i,1);
		var fc   = cnt+2;
		suma += parseInt(dig, 10) * fc;
		var cnt  = (cnt+1) % 6;
	}
	var dvok = 11 - ( suma % 11 );
	if (dvok == 11) var dvokstr="0";
	if (dvok == 10) var dvokstr="K";
	if ((dvok != 11) && (dvok != 10)) var dvokstr = "" + dvok;
	if ( dvokstr == dv )
		return true;
	else
		return false;
}

/**
 * Validar dirección de correo electrónico.
 * Utiliza la validación de HTML5 si está disponible en el navegador
 * @param  {string} correo Correo electrónico
 * @return {bool} Verdadero si corresponde a un correo electrónico válido
 */
var validarEmail = function( correo ){
	// vamos a usar la validacion html5 para comprobar si el mail tiene un formato válido
	var inputEmail = document.createElement('INPUT');
	inputEmail.type = 'email';
	inputEmail.value = correo;
	if ( typeof inputEmail.checkValidity === 'function' ) {
		return inputEmail.checkValidity();
	} else {
		// se debe utilizar otro método para validar el e-mail
		throw 'El navegador no soporta validación de correo';
		return true;
	}
}


var Direccion = function(){
	/**
	 * Dirección estandarizada breve
	 * @type {String}
	 */
	this.direccion_estandarizada = '';

	/**
	 * Dirección estandarizada en detalle
	 * @type {String}
	 */
	this.direccion_detallada = '';

	/**
	 * Nombre de la Región
	 * @type {String}
	 */
	this.region = 'Región Metropolitana';

	/**
	 * Nombre de la ciudad
	 * @type {String}
	 */
	this.ciudad = 'Santiago';

	/**
	 * Nombre de la comuna
	 * @type {String}
	 */
	this.comuna = 'Santiago';

	/**
	 * Nombre de la calle
	 * @type {String}
	 */
	this.calle  = ''

	/**
	 * Numeración de la dirección de calle
	 * @type {String}
	 */
	this.numeracion = '';

	/**
	 * Número de la unidad (departamento, casa de condominio, etc)
	 * @type {String}
	 */
	this.unidad = '';

	/**
	 * Código postal
	 * @type {String}
	 */
	this.codigo_postal = 'XXXXX';

	/**
	 * Nombre del País
	 * @type {String}
	 */
	this.pais = 'Chile';

	/**
	 * Código ISO 3166 alpha 2 del país
	 * @type {String}
	 */
	this.codigo_pais = 'cl';

	/**
	 * Objeto de posición geográfica
	 * - lat: latitud, en rango de -90 a 90 grados (sur → norte)
	 * - long: longitud, en rango de -180 a 180 grados (oeste → este)
	 * @type {Object}
	 */
	this.lat_long = {
		lat: 0,
		long: 0
	};
	this.setDireccionEstandarizada = function( dir_est ){
		this.direccion_estandarizada = dir_est;
		return this;
	}
	this.setDireccionDetallada = function( dir_det ){
		this.direccion_detallada = dir_det;
		return this;
	}
	this.setRegion = function( region ){
		this.region = region;
		return this;
	}
	this.setCiudad = function( ciudad ){
		this.ciudad = ciudad;
		return this;
	}
	this.setComuna = function( comuna ){
		this.comuna = comuna;
		return this;
	}
	this.setCalle = function( calle ){
		this.calle = calle;
		return this;
	}
	this.setNumeracion = function( numeracion ){
		this.numeracion = numeracion;
		return this;
	}
	this.setUnidad = function( unidad ){
		this.unidad = unidad;
		return this;
	}
	this.setCodigoPostal = function( codigo ){
		this.codigo = codigo.toUpperCase();
		return this;
	}
	this.setCasilla = function( casilla ){
		this.casilla = casilla;
		return this;
	}
	this.setPais = function( pais ){
		this.pais = pais;
		return this;
	}
	this.setCodigoPais = function( codigo ){
		this.codigo_pais = codigo.toLowerCase();
		return this;
	}
	this.setLatLong = function( lat_long ){
		var obj_ll = this.lat_long;
		var new_ll = {};
		if ( lat_long.lat >= -90 && lat_long.lat <= 90 ) {
			new_ll.lat = lat_long.lat;
		}
		if ( lat_long.long >= -180 && lat_long.long <= 180 ){
			new_ll.long = lat_long.long;
		}
		var new_ll = $.extend( obj_ll, new_ll );
		this.lat_long = new_ll;
		return this;
	}
	this.construirDireccion = function( props ){
		var direccion = $.extend({
			region: 'Región Metropolitana',
			ciudad: 'Santiago',
			comuna: 'Santiago',
			calle: '',
			numeracion: '',
			unidad: '',
			codigo_postal: '',
			casilla: '',
			pais: 'Chile',
			codigo_pais: 'cl',
			lat_long: {
				lat: 0,
				long: 0
			}
		}, props);
		for ( var i in direccion ) {
			var compound_name = i.indexOf('_');
			if ( compound_name !== -1 ) {
				// convertir de snake_case a camelCase;
				var setter_name = 'set';
				setter_name += i.charAt(0).toUpperCase();
				setter_name += i.substr(1, compound_name - 1 );
				setter_name += i.charAt( compound_name + 1 ).toUpperCase();
				setter_name += i.substr( compound_name + 2 );
			} else {
				var setter_name = 'set' + i.charAt(0).toUpperCase() + i.substr(1);
			}
			this[setter_name]( direccion[i] );
		}
		this.setDireccionEstandarizada( direccion.calle +' '+ direccion.numeracion + ( direccion.unidad ? ' '+ direccion.unidad : '' ) +', '+ direccion.comuna );
		this.setDireccionDetallada( direccion.calle +' '+ direccion.numeracion + ( direccion.unidad ? ' '+ direccion.unidad : '' ) +', '+ direccion.comuna +', '+ direccion.ciudad +', '+ direccion.region +' '+ direccion.pais );
	}
}

var Sucursal = function(){
	this.nombre = '';
	this.direccion = null;
	this.horario = {
		lunes_a_viernes: '',
		sabado: '',
		domingo: ''
	};
	this.telefono = '';
	this.fax = '';
	this.setNombre = function( nombre ){
		this.nombre = nombre;
		return this;
	}
	this.setDireccion = function( Direccion ){
		this.direccion = Direccion;
		return this;
	}
	this.setHorario = function( Horario ){
		var obj_horario = this.horario;
		// utilizando el método de jQuery para extender el objeto original
		var nuevo_horario = $.extend( obj_horario, Horario );
		this.horario = nuevo_horario;
		return this;
	}
	this.setTelefono = function( telefono ){
		this.telefono = telefono;
		return this;
	}
	this.setFax = function( fax ){
		this.fax = fax;
		return this;
	}
}

/**
 * Clase modelo para Destinatarios.
 * Se extiende para ajustarse según sea nacional o internacional
 * @return {Destinatario} [description]
 */
var Destinatario = function(){
	this.nombre = '';
	this.email = '';
	this.telefono = '';
	this.setNombre = function( nombre ){
		this.nombre = nombre;
		return this;
	}
	this.setEmail = function( correo ){
		if ( validarEmail( correo ) ) {
			this.email = correo;
		}
		return this;
	}
	this.setTelefono = function( telefono ){
		if ( telefono.length > 4 ) {
			this.telefono = telefono;
		}
		return this;
	}
}
var DestinatarioNacional = function(){
	Destinatario.call(this);
	this.Direccion = null;
	this.rut = '';
	this.setDireccion = function( Direccion ){
		this.Direccion = Direccion;
		return this;
	}
	this.setRut = function( rut ){
		if ( validarRut(rut) ) {
			this.rut = rut;
		}
		return this;
	}
}
DestinatarioNacional.prototype = new Destinatario;

var DestinatarioInternacional = function(){
	Destinatario.call(this);
	this.Sucursal = null;
	this.setSucursal = function( Sucursal ){
		this.Sucursal = Sucursal;
		return this;
	}
}
DestinatarioInternacional.prototype = new Destinatario;

var OrdenDeCompra = {
	Paquetes : [],
	Remitente: null,
	Destinatario: null,
	agregarPaquetes : function( Paquetes ){
		Paquetes = Paquetes.lista;
	},
	setRemitente : function( Remitente ){
		Remitente = Remitente;
	},
	setDestinatario : function( Destinatario ){
		Destinatario = Destinatario;
	}
}
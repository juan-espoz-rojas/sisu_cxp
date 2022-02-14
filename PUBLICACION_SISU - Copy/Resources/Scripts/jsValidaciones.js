function jsConfirmacion(psMensaje) {

    return confirm(psMensaje);
}

function ValidaCopyPasteCut(textbox,tipoValidacion) {
  
    if (tipoValidacion == 1)   //valida que no se copie
    {
        $("#" + textbox).bind('copy', function (e) {
            return false;
        });
    }

    if (tipoValidacion == 2)  //valida que no se pegue
    {   
        $("#" + textbox).bind('paste', function (e) {
            return false;
        });
    }

    if (tipoValidacion == 3) //valida que no se corte
    {  
        $("#" + textbox).bind('cut', function (e) {
            return false;
        });
    }

    if (tipoValidacion == 4)   //valida que no se copie y pegue
    {
        $("#" + textbox).bind('copy', function (e) {
            return false;
        });
        $("#" + textbox).bind('paste', function (e) {
            return false;
        });
    }

    if (tipoValidacion == 5)  //valida que no se copie y corte                                                                                                                                                             
    {
        $("#" + textbox).bind('copy', function (e) {
            return false;
        });
        $("#" + textbox).bind('cut', function (e) {
            return false;
        });
    }

    if (tipoValidacion == 6) //valida que no se pegue y corte                                                                                                                                                                 
    {
        $("#" + textbox).bind('paste', function (e) {
            return false;
        });
        $("#" + textbox).bind('cut', function (e) {
            return false;
        });
    }

    if (tipoValidacion == 7)  //valida que no se copie, pegue y corte
    {
        $("#" + textbox).bind('copy', function (e) {
            return false;
        });
        $("#" + textbox).bind('paste', function (e) {
            return false;
        });
        $("#" + textbox).bind('cut', function (e) {
            return false;
        });
    }
}


function jsValidaRutCompleto(TxtRut, TxtDgv) {

    //    rut = $("#" + TxtRut).val();
    //    dv = $("#" + TxtDgv).val();
    rut = TxtRut;
    dv = TxtDgv;

    var dvr = '0';
    suma = 0;
    mul = 2;

    for (i = rut.length - 1; i >= 0; i--) {
        suma = suma + rut.charAt(i) * mul;
        if (mul == 7) mul = 2;
        else {
            mul++;
        }
    }

    res = suma % 11;
    if (res == 1) {

        dvr = 'k';
    }
    else if (res == 0) {

        dvr = '0';
    }
    else {
        dvi = 11 - res;
        dvr = dvi + "";
    }

    if (dvr != dv.toLowerCase()) {
        MensajeAlerta("El d&iacutegito verificador no corresponde al Rut.");
        return false;
    }
    else {
        return true;
    }

}

/*    
NOMBRE FUNCION   : ValidaRutCompleto
OBJETIVO(S)              :

1-Validar el largo y entrada del rut

ENTRADA                   :Nombre del TextBox Rut
Nombre dek TextBox Digito Verificador
                                     
                                     
RETORNO                   :true si la validacion es correcta
false y mensaje si la validacion es erronea
                                     
DESARROLLADOR    : Patricio Matamala Segura
*/

function ValidaRutCompleto(TxtRut, TxtDgv) {
    rut = $("#" + TxtRut).val();
    dv = $("#" + TxtDgv).val();

    if (rut.length == 0 && dv.length == 0)  // rut y dv vacíos
    {
        return true;
    }
    else if (dv.length == 1 && rut.length == 0)//si existe el digito verificador  y no existe rut
    {
        MensajeAlerta("El Rut se encuentra vac&iacuteo.");
        return false;
    }
    else if (dv.length == 0 && rut.length > 0)//si existe el rut y no existe el digito verificador
    {
        MensajeAlerta("El D&iacutegito verificador se encuentra vac&iacuteo.");
        return false;
    }
    else if (rut.length < 1 || rut.length > 8)//valida que el rut sea entre 1 y 99.999.999
    {
        MensajeAlerta("El Rut debe ser un n&uacutemero entre 1 y 99.999.999");
        return false;
    }
    else if (rut == "0")//valida que el rut sea entre 1 y 99.999.999
    {
        MensajeAlerta("El Rut debe ser un n&uacutemero entre 1 y 99.999.999");
        return false;
    }
    else {

        var dvr = '0';
        suma = 0;
        mul = 2;

        for (i = rut.length - 1; i >= 0; i--) {
            suma = suma + rut.charAt(i) * mul;
            if (mul == 7) mul = 2;
            else {
                mul++;
            }
        }

        res = suma % 11;
        if (res == 1) {

            dvr = 'k';
        }
        else if (res == 0) {

            dvr = '0';
        }
        else {
            dvi = 11 - res;
            dvr = dvi + "";
        }

        if (dvr != dv.toLowerCase()) {
            MensajeAlerta("El D&iacutegito Verificador no corresponde al Rut.");
            return false;
        }
    }

    return true;


}

//**Excluye pegado de caracteres Invalidos**//
function ValidarPegaCaracteres(textbox,opcion,signos) {
    $("#" + textbox).blur(function () {
        texto = $("#" + textbox).val();
       
        var numeros = "1234567890";
        var letras = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJQLMNÑOPQRSTUVWXYZ áéíóúÁÉÍÓÚ";
        var correo = "@._";
        var signo = "-";
        var digitoverificador = "kK";
        var puntuacion = ".,";
        var coma = ",";
        var varios = "@._+-.,;:!¡¿?/()*><°=";

        var resultado = "";

        if (opcion == 1) {//solo numeros
            resultado = numeros;
        }
        else if (opcion == 2) {//solo letras
            resultado = letras;
        }
        else if (opcion == 3) {//alfanumericos
            resultado = letras + numeros;
        }
        else if (opcion == 4) {//e-mail
            resultado = letras + numeros + correo;
        }
        else if (opcion == 5) {//caracteres
            resultado = letras + numeros + varios;
        }
        else if (opcion == 6) {//digitoverificador
            resultado = numeros + digitoverificador;
        }
        else if (opcion == 7) {//numeros de certificados
            resultado = letras + numeros + signo;
        }
        else if (opcion == 8) {//numeros de certificados
            resultado = letras + varios;
        }


        if (signos == 1) {//signo
            resultado += signo;
        }
        else if (signos == 2) {//signo y puntuacion
            resultado += signo + puntuacion;
        }
        else if (signos == 3) {//coma
            resultado += coma;
        }

        for (var i = 0, output = '', validos = resultado; i < texto.length; i++)
            if (validos.indexOf(texto.charAt(i)) != -1)
                output += texto.charAt(i)

        $("#" + textbox).val(output); // Reemplaza el texbox con los caracteres validos

    }
    )
}

//**Excluye caracteres Invalidos**//
function ValidarCaractereskeypress(textbox, opcion, signos) 
{
    $("#" + textbox).keypress(function (e) {

        if (e.which < 32) {
            return true;
        }
        else {

            var numeros = "1234567890";
            var letras = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJQLMNÑOPQRSTUVWXYZ áéíóúÁÉÍÓÚ";
            var correo = "@._";
            var signo = "-";
            var digitoverificador = "kK";
            var puntuacion = ".,";
            var coma = ",";
            var varios = "@._+-.,;:!¡¿?/()*><°=";

            var resultado = "";

            if (opcion == 1) {//solo numeros
                resultado = numeros;
            }
            else if (opcion == 2) {//solo letras
                resultado = letras;
            }
            else if (opcion == 3) {//alfanumericos
                resultado = letras + numeros;
            }
            else if (opcion == 4) {//e-mail
                resultado = letras + numeros + correo;
            }
            else if (opcion == 5) {//caracteres
                resultado = letras + numeros + varios;
            }
            else if (opcion == 6) {//digitoverificador
                resultado = numeros + digitoverificador;
            }
            else if (opcion == 7) {//numeros de certificados
                resultado = letras + numeros + signo;
            }

            if (signos == 1) {//signo
                resultado += signo;
            }
            else if (signos == 2) {//signo y puntuacion
                resultado += signo + puntuacion;
            }
            else if (signos == 3) {//coma
                resultado += coma;
            }

            if (resultado.indexOf(String.fromCharCode(e.which)) != -1) {
                return true;
            }
            else {
                return false;
            }
        }

    });

}

//**Excluye caracteres Invalidos**//
function ValidarCaractereskeypressControles(textbox, opcion, signos) {
    $(textbox).keypress(function (e) {

        var numeros = "1234567890";
        var letras = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJQLMNÑOPQRSTUVWXYZ áéíóúÁÉÍÓÚ";
        var correo = "@._";
        var signo = "-";
        var digitoverificador = "kK";
        var puntuacion = ".,";
        var coma = ",";
        var varios = "@._+-.,;:!¡¿?/()*°=";

        var resultado = "";

        if (opcion == 1) {//solo numeros
            resultado = numeros;
        }
        else if (opcion == 2) {//solo letras
            resultado = letras;
        }
        else if (opcion == 3) {//alfanumericos
            resultado = letras + numeros;
        }
        else if (opcion == 4) {//e-mail
            resultado = letras + numeros + correo;
        }
        else if (opcion == 5) {//caracteres
            resultado = letras + numeros + varios;
        }
        else if (opcion == 6) {//digitoverificador
            resultado = numeros + digitoverificador;
        }
        else if (opcion == 7) {//numeros de certificados
            resultado = letras + numeros + signo;
        }

        if (signos == 1) {//signo
            resultado += signo;
        }
        else if (signos == 2) {//signo y puntuacion
            resultado += signo + puntuacion;
        }
        else if (signos == 3) {//coma
            resultado += coma;
        }

        if (resultado.indexOf(String.fromCharCode(e.which)) != -1) {
            return true;
        }
        else {
            return false;
        }


    });

}

function jsContador(Texto, Contador, LargoMaximo) {


$("#" + Texto).keyup(function () {

    if ($(this).val().length > LargoMaximo) {


        var descripcion = $(this).text();
        $(this).text(descripcion.substring(0, LargoMaximo));

        $("#" + Contador).text(LargoMaximo - $(this).val().length);


        alert('Usted super&oacute el m&aacuteximo de caracteres de entrada. El sistema eliminar&aacute el contenido adicional.');

    }
    else {

        $("#" + Contador).text(LargoMaximo - $(this).val().length);
    }


});

}

/*    
NOMBRE FUNCION   : AnularTeclarEntrada
OBJETIVO(S)              :

1-No permitir escribir en el textbox al presionar una tecla

ENTRADA                   :Nombre del TextBox 
Anular entrada evento key press ; keypress=1 anular ;keypress=0 No anular                   
Anular entrada evento key down ; keydown=1 anular;keypress=0 No anular     
Anular entrada evento key up ; keyup=1 anular;keypress=0 No anular  
teclakeypress=0; anula todas las entradas; teclakeypress   = a un numero de tecla, anula la tecla que se indique           
teclakeydown=0; anula todas las entradas; teclakeydown   = a un numero de tecla, anula la tecla que se indique     
teclakeyup=0; anula todas las entradas; teclakeyup   = a un numero de tecla, anula la tecla que se indique     
                                      
RETORNO                   :Retorna valor cuando la validacion asignada no se cumple
No retorna valor cuando los parametros de entrada para la validacion se cumplen
                                     
DESARROLLADOR    : Patricio Matamala Segura
en la pagina aparece el numero al presionar una tecla(debes presionar una tecla para que te muestre)->http://www.desarrolloweb.com/articulos/ejemplos/jquery/eventos/eventos-teclado0.html
*/
function AnularTeclarEntrada(textbox, keypress, keydown, keyup, teclakeypress, teclakeydown, teclakeyup) {
    if (keypress == 1) {
        $("#" + textbox).keypress(function (e) {                                                                                                                                     //anula al presionar el teclado                        

            if (e.which == teclakeypress && teclakeypress > 0) {
                e.preventDefault(); //anula la entrada de texto. 
            }
            if (teclakeypress == 1) {

                return false;
            }
            else { return true; }

        });
    }

    if (keydown == 1) {
        $("#" + textbox).keydown(function (e) {                                                                                                                                      //anula al soltar la tecla  

            if (e.which == teclakeydown && teclakeydown > 0) {
                e.preventDefault(); //anula la entrada de texto. 
            }
            if (teclakeydown == 0) {

                return false;
            }
            else { return true; }

        });
    }

    if (keyup == 1) {
        $("#" + textbox).keyup(function (e) {                                                                                                                                          //anula al soltar el teclado      

            if (e.which == teclakeyup && teclakeyup > 0) {
                e.preventDefault(); //anula la entrada de texto. 
            }
            if (teclakeyup == 0) {

                return false;
            }
            else { return true; }

        });
    }
    return true;


}


/*    
NOMBRE FUNCION   : ValidaNumeroEntero
OBJETIVO(S)              :

1-Permitir validacion de numeros enteros en la entrada de texto

ENTRADA                   :Nombre del TextBox 
Tipo de validacion 
1=validar el ingreso de numeros enteros positivos sin signo
2=validar el ingreso de numeros enteros negativos con signo  
RETORNO                   :NA.
                                     
DESARROLLADOR    : Patricio Matamala Segura
*/
function ValidaNumeroEntero(textbox, tipoValidacion) {
    $("#" + textbox).keypress(function (e) {

        if (tipoValidacion == 1)                                                                                                                                                           //opcion validar positivos sin cero al inicio
        {
            if (e.which >= 48 && e.which <= 57)                                                                                                                            //valida entrada 0,1,2,3,4,5,6,7,8,9
            {
                if (($("#" + textbox).val().length == 0) && (e.which == 48))                                                                                   //valida que el primer parametro no sea un cero
                {
                    return false;
                }
                else                                                                                                                                                                                //permite ingresar todos los numeros enteros
                {
                    return true;
                }
            }
            else {
                return false;
            }
        }
        else if (tipoValidacion == 2)                                                                                                                                                    //opcion validar negativos sin cero al inicio 
        {

            if (($("#" + textbox).val().length == 0) && (e.which == 45))                                                                                       //valida que el primer parametro sea un -
            {
                return true;
            }
            else if ($("#" + textbox).val().length > 0 && e.which >= 48 && e.which <= 57)                                                     //valida la entrada de datos 0,1,2,3,4,5,6,7,8,9,
            {
                if (($("#" + textbox).val().length == 1) && (e.which == 48))                                                                                  //no permite ingresar en la segunda posicion un 0
                {
                    return false;
                }
                else {
                    return true;
                }
            }
            else {
                return false;
            }
        }



    });

}

/*    
NOMBRE FUNCION          : ValidarNumeroDecimal
OBJETIVO(S)              :

1-Permite ingresar numeros decimales

ENTRADA                   :textbox a validar
numero de enteros permitidos 
valor maximo que no puede superar el valor ingresado
                                                                 
RETORNO                   :NA.
                                     
DESARROLLADOR    : Patricio Matamala S.
*/
function ValidarNumeroDecimal(textbox, numero_enteros, numero_decimales) {

    //Caracter ( , ) valor 44
    //numeros 0...9 rango ascii  decimal 48 al 57
    //numeros 0...9 rango 96 al 105 cuando ocurre evento keyup

    $("#" + textbox).bind(
           {
               click: function ()//al hacer clicl 
               {
                   var texto = $(this).val();

                   if ($(this).val() == "0,00" || $(this).val() == "0") //elimina los ceros para que el funcionario ingrese el valor de entrada                                                                                                                                   //elimina el contenido 0,00000 ya que es un ejemplo de como anotar los decimales
                   {
                       $(this).val("");
                   }
               }
                      ,
//               blur: function (event)//al perder el foco
//               {                                                                                                                                                                   //valida al terminar perder el foco

//               }
//                      ,
               keyup: function (e)//cuando el usuario suelta la tecla
               {

                   var texto = $(this).val();
                   var largo = texto.length;
                   var existeComa = false;
                   var posicionComa = 0;
                   var parteDecimal = "00";
                   var parteEntera = "0";

                   //permite  0...9 rango 96 al 105 cuando ocurre evento keyup //numeros 0...9 rango ascii  decimal 48 al 57
                   //                                if((e.which>=96 && e.which<=105) || (e.which>=48 && e.which<=57) )//permite ingresar numeros
                   //                                {
                   //             
                   //                                        if(texto)//si existe texto
                   //                                        {
                   for (i = 0; i < largo; i++)                                                                                                                                   //buscamos una coma para validar los decimales
                   {
                       if (texto.charCodeAt(i) == 44) {
                           existeComa = true;
                           posicionComa = i;
                       }
                   }
                   if (existeComa) //existe coma                                                                                                                                           //si existen decimales
                   {


                       parteDecimal = $(this).val().substring(posicionComa + 1, largo + 1); //obtenemos la parte decimal
                       parteEntera = $(this).val().substring(0, posicionComa);           //obtenemos la parte entera                           

                       if (parteDecimal.length > numero_decimales)                                                                                                               //limita a un maximo de 5 decimales
                       {
                           parteDecimal = parteDecimal.substring(0, numero_decimales);
                       }

                       if (parteEntera.length > numero_enteros)                                                                                                                    //limina a un maximo de entero largo 3
                       {
                           parteEntera = parteEntera.substring(0, numero_enteros);
                           parteEntera = parseInt(parteEntera);
                       }

                       $(this).val(parteEntera + "," + parteDecimal);
                       return true;                                                                                       //asigna valor correcto
                   }
                   else //no existe coma
                   {

                       parteEntera = $(this).val();

                       if (parteEntera.length > numero_enteros)                                                                                                                    //valida numero maximo 999
                       {
                           parteEntera = parteEntera.toString().substring(0, numero_enteros);
                       }
                       else {
                           return true;
                       }
                       //parteEntera= parseInt( parteEntera,10);

                       $(this).val(parteEntera);
                       //return false;

                   }
                   //                                         }  
                   //                                
                   //                                        return true;
                   //                                }    
               },
               keypress: function (e) {

                   var texto = $(this).val();
                   var largo = texto.length;
                   var largoEntero = 0;
                   var largoDecimal = 0;
                   var existeComa = false;
                   var posicionComa = 0;
                   var parteDecimal = "00";
                   var parteEntera = "0";

                   if (e.which == 44 && largo == 0)//no se puede ingresar una coma en la posicion cero
                   {
                       return false;
                   }
                   else if (e.which >= 48 && e.which <= 57) {

                   }
                   else if (e.which == 44 && largo >= 1)//permite ingresar coma cuando ya se ingreso un numero
                   {

                       existeComa = false;

                       for (i = 0; i < largo; i++)//valida que no exista otra coma
                       {
                           if (texto.charCodeAt(i) == 44) {
                               existeComa = true;
                           }
                       }
                       if (existeComa) {
                           return false;
                       }
                       else {
                           return true;
                       }
                   }
                   else {
                       return false;
                   }


               }


           });                                                                                                                                                                                        //fin del bind

}
/*    
NOMBRE FUNCION          : ValidarNumeroDecimal
OBJETIVO(S)              :

1-Permite ingresar numeros decimales

ENTRADA                   :textbox a validar
numero de enteros permitidos 
valor maximo que no puede superar el valor ingresado
                                                                 
RETORNO                   :NA.
                                     
DESARROLLADOR    : Patricio Matamala S.
*/
function ValidarNumeroDecimalPostback(textbox, numero_enteros, numero_decimales) {

    //Caracter ( , ) valor 44
    //numeros 0...9 rango ascii  decimal 48 al 57
    //numeros 0...9 rango 96 al 105 cuando ocurre evento keyup

    $("#" + textbox).bind(
           {
               click: function ()//al hacer clicl 
               {
                   var texto = $(this).val();

                   if ($(this).val() == "0,00" || $(this).val() == "0") //elimina los ceros para que el funcionario ingrese el valor de entrada                                                                                                                                   //elimina el contenido 0,00000 ya que es un ejemplo de como anotar los decimales
                   {
                       $(this).val("");
                   }
               }
                ,
                blur: function (event)//al perder el foco
                {
                    InicioProgressBarCenterLeft(490);                                                                                                                                                 //valida al terminar perder el foco
                    __doPostBack('lnkRecargar', '');
                }
                ,
               keyup: function (e)//cuando el usuario suelta la tecla
               {

                   var texto = $(this).val();
                   var largo = texto.length;
                   var existeComa = false;
                   var posicionComa = 0;
                   var parteDecimal = "00";
                   var parteEntera = "0";

                   //permite  0...9 rango 96 al 105 cuando ocurre evento keyup //numeros 0...9 rango ascii  decimal 48 al 57
                   //                                if((e.which>=96 && e.which<=105) || (e.which>=48 && e.which<=57) )//permite ingresar numeros
                   //                                {
                   //             
                   //                                        if(texto)//si existe texto
                   //                                        {
                   for (i = 0; i < largo; i++)                                                                                                                                   //buscamos una coma para validar los decimales
                   {
                       if (texto.charCodeAt(i) == 44) {
                           existeComa = true;
                           posicionComa = i;
                       }
                   }
                   if (existeComa) //existe coma                                                                                                                                           //si existen decimales
                   {


                       parteDecimal = $(this).val().substring(posicionComa + 1, largo + 1); //obtenemos la parte decimal
                       parteEntera = $(this).val().substring(0, posicionComa);           //obtenemos la parte entera                           

                       if (parteDecimal.length > numero_decimales)                                                                                                               //limita a un maximo de 5 decimales
                       {
                           parteDecimal = parteDecimal.substring(0, numero_decimales);
                       }

                       if (parteEntera.length > numero_enteros)                                                                                                                    //limina a un maximo de entero largo 3
                       {
                           parteEntera = parteEntera.substring(0, numero_enteros);
                           parteEntera = parseInt(parteEntera);
                       }

                       $(this).val(parteEntera + "," + parteDecimal);
                       return true;                                                                                       //asigna valor correcto
                   }
                   else //no existe coma
                   {

                       parteEntera = $(this).val();

                       if (parteEntera.length > numero_enteros)                                                                                                                    //valida numero maximo 999
                       {
                           parteEntera = parteEntera.toString().substring(0, numero_enteros);
                       }
                       else {
                           return true;
                       }
                       //parteEntera= parseInt( parteEntera,10);

                       $(this).val(parteEntera);
                       //return false;

                   }
                   //                                         }  
                   //                                
                   //                                        return true;
                   //                                }    
               },
               keypress: function (e) {

                   var texto = $(this).val();
                   var largo = texto.length;
                   var largoEntero = 0;
                   var largoDecimal = 0;
                   var existeComa = false;
                   var posicionComa = 0;
                   var parteDecimal = "00";
                   var parteEntera = "0";

                   if (e.which == 44 && largo == 0)//no se puede ingresar una coma en la posicion cero
                   {
                       return false;
                   }
                   else if (e.which >= 48 && e.which <= 57) {

                   }
                   else if (e.which == 44 && largo >= 1)//permite ingresar coma cuando ya se ingreso un numero
                   {

                       existeComa = false;

                       for (i = 0; i < largo; i++)//valida que no exista otra coma
                       {
                           if (texto.charCodeAt(i) == 44) {
                               existeComa = true;
                           }
                       }
                       if (existeComa) {
                           return false;
                       }
                       else {
                           return true;
                       }
                   }
                   else {
                       return false;
                   }


               }


           });                                                                                                                                                                                        //fin del bind

}
/*    
NOMBRE FUNCION   : ValidaEntradaYLargoRut
OBJETIVO(S)              :

1-Validar el largo y entrada del digito verificador

ENTRADA                   :Nombre del TextBox 
                                     
RETORNO                   :NA.
                                     
DESARROLLADOR    : Patricio Matamala Segura
*/
function ValidaEntradaYLargoRut(TxtRut) {
    $("#" + TxtRut).keypress(function (e) {

        if ((e.which >= 48 && e.which <= 57) && $("#" + TxtRut).val().length < 8)                                                                                                                            //valida entrada 0...9 y largo 8
        {
            return true;
        }
        else {
            return false;
        }
    });

}
/*
NOMBRE FUNCION   : ValidaEntradaYLargoDGV
OBJETIVO(S)              :

        1-Validar el largo y entrada del digito verificador

ENTRADA                   :Nombre del TextBox 
                                     
RETORNO                   :NA.
                                     
DESARROLLADOR    : Patricio Matamala Segura
*/
function ValidaEntradaYLargoDGV(TxtDgv) 
{

//Caracter (k) 107
//Caracter (K) 75
    $("#"+TxtDgv).keypress(function(e){


        if((e.which>=48 && e.which <=57 ||  e.which==75 || e.which==107) && $("#"+TxtDgv).val().length<1)//Permite ingresar Rut con valor entre 0...9 , k y largo 1                                                                                                                           //valida entrada 0,1,2,3,4,5,6,7,8,9
        {
                    return true;          
         }
         else
         {
                    return false;
         }
    });

}





function esFechaValida(fecha) {
    if (fecha != undefined && fecha.value != "") {
        if (!/^\d{2}\/\d{2}\/\d{4}$/.test(fecha.value)) {
            alert("formato de fecha no válido (dd/mm/aaaa)");
            fecha.value = "";
            return false;
        }
        var dia = parseInt(fecha.value.substring(0, 2), 10);
        var mes = parseInt(fecha.value.substring(3, 5), 10);
        var anio = parseInt(fecha.value.substring(6), 10);

        switch (mes) {
            case 1:
            case 3:
            case 5:
            case 7:
            case 8:
            case 10:
            case 12:
                numDias = 31;
                break;
            case 4: case 6: case 9: case 11:
                numDias = 30;
                break;
            case 2:
                if (comprobarSiBisisesto(anio)) { numDias = 29 } else { numDias = 28 };
                break;
            default:
                alert("Fecha introducida errónea");
                fecha.value = "";
                return false;
        }
        if (dia > numDias || dia == 0) {
            alert("Fecha introducida errónea");
            fecha.value = "";
            return false;
        }
        return true;
    }
}

function comprobarSiBisisesto(anio) {
    if ((anio % 100 != 0) && ((anio % 4 == 0) || (anio % 400 == 0))) {
        return true;
    }
    else {
        return false;
    }
}

function SeteaRolTerreno(txtRol) {
    var arreglo = new Array();
    var contadorDerecho;
    var contadorIzquierda;
    var suma;
    var p1;
    var p2;

    arreglo = txtRol.value.split('-');

    if (arreglo[0] != undefined)
        contadorDerecho = '00000' + arreglo[0];
    else
        contadorDerecho = '00000'

    if (arreglo[1] != undefined)
        contadorIzquierda = '00000' + arreglo[1];
    else
        contadorIzquierda = '00000'

    p1 = parseInt(contadorIzquierda, 10);
    p2 = parseInt(contadorDerecho, 10);
    suma = p1 + p2;
    if (suma != 0)
        txtRol.value = Right(contadorDerecho, 5) + '-' + Right(contadorIzquierda, 5);
    else
        txtRol.value = '';
}

function Right(str, n) {
    if (n <= 0)
        return "";
    else if (n > String(str).length)
        return str;
    else {
        var iLen = String(str).length;
        return String(str).substring(iLen, iLen - n);
    }
}
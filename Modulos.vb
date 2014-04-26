
Module Modulos
    'TABLAS DE LOS MODULOS
    'contabilidad
    Public Sub Generales(ByVal bd As String)
        'TABLA ERROR
        myCommand.CommandText = " CREATE TABLE IF NOT EXISTS " & bd & ".`error` (" _
         & " `num` INT NOT NULL AUTO_INCREMENT , " _
         & " `form` VARCHAR( 60 ) NOT NULL , " _
         & " `msj` TEXT NOT NULL , " _
         & " `fecha` DATE NOT NULL , " _
         & " INDEX (  `num` ) " _
         & "  ) ENGINE = MyISAM DEFAULT CHARSET=latin1; "
        myCommand.ExecuteNonQuery()

        'CREAR TABLA TIPOS DE DOCUMENTOS
        myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".tipdoc (`tipodoc` varchar(2) NOT NULL, `grupo` varchar(30) NOT NULL,  `descripcion` varchar(30) NOT NULL, " _
        & "`iniciofc` bigint(20) NOT NULL DEFAULT '0',  `actualfc` bigint(20) NOT NULL DEFAULT '0',  `inicio01` bigint(20) NOT NULL,  `actual01` bigint(20) NOT NULL,  `inicio02` bigint(20) NOT NULL DEFAULT '0',  `actual02` bigint(20) NOT NULL DEFAULT '0',  `inicio03` bigint(20) NOT NULL DEFAULT '0',  `actual03` bigint(20) NOT NULL DEFAULT '0',  `inicio04` bigint(20) NOT NULL DEFAULT '0',  `actual04` bigint(20) NOT NULL DEFAULT '0',  `inicio05` bigint(20) NOT NULL DEFAULT '0'," _
        & "`actual05` bigint(20) NOT NULL DEFAULT '0',`inicio06` bigint(20) NOT NULL DEFAULT '0',`actual06` bigint(20) NOT NULL DEFAULT '0',`inicio07` bigint(20) NOT NULL DEFAULT '0',`actual07` bigint(20) NOT NULL DEFAULT '0',`inicio08` bigint(20) NOT NULL DEFAULT '0',`actual08` bigint(20) NOT NULL DEFAULT '0',`inicio09` bigint(20) NOT NULL DEFAULT '0',`actual09` bigint(20) NOT NULL DEFAULT '0',`inicio10` bigint(20) NOT NULL DEFAULT '0',`actual10` bigint(20) NOT NULL DEFAULT '0'," _
        & "`inicio11` bigint(20) NOT NULL DEFAULT '0',`actual11` bigint(20) NOT NULL DEFAULT '0',`inicio12` bigint(20) NOT NULL DEFAULT '0',`actual12` bigint(20) NOT NULL DEFAULT '0', PRIMARY KEY (`tipodoc`)) ENGINE=MyISAM DEFAULT CHARSET=utf8;"
        myCommand.ExecuteNonQuery()
        'CREAR TABLA TERCEROS
        myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".terceros (" _
                              & "`nit` varchar(20) NOT NULL DEFAULT '',`dv` varchar(2) NOT NULL,`nombre` varchar(100) NOT NULL DEFAULT '',`apellidos` varchar(50) DEFAULT '.',`tipo` varchar(20) NOT NULL DEFAULT 'CLIENTES',`persona` varchar(20) NOT NULL DEFAULT 'natural',`dir` varchar(100) NOT NULL DEFAULT '(ninguna)'," _
                              & "`pais` varchar(10) NOT NULL,`dept` varchar(10) NOT NULL,`mun` varchar(10) NOT NULL," _
                              & "`telefono` varchar(20) DEFAULT '(ninguno)',  `celular` varchar(20) DEFAULT '(ninguno)', `fax` varchar(20) DEFAULT '(ninguno)', `correo` varchar(150) DEFAULT '(ninguno)', `web` varchar(150) DEFAULT '(ninguno)'," _
                              & "`dia` varchar(2) NOT NULL,`mes` varchar(15) NOT NULL,`contacto` varchar(100) NOT NULL,`telconta` varchar(15) NOT NULL,`cupo` double NOT NULL,`vmto` bigint(20) NOT NULL,`iva` varchar(2) NOT NULL,`retef` varchar(2) NOT NULL,`reteiva` varchar(2) NOT NULL,`reteica` varchar(2) NOT NULL, " _
                              & " `nomina` varchar(5) NOT NULL DEFAULT '[NUL]', `retecree` VARCHAR( 2 ) NOT NULL DEFAULT  'NO', `act1` VARCHAR( 6 ) NOT NULL DEFAULT  '0',`act2` VARCHAR( 6 ) NOT NULL DEFAULT  '0',   `act3` VARCHAR( 6 ) NOT NULL DEFAULT  '0', `act4` VARCHAR( 6 ) NOT NULL DEFAULT  '0'," _
                              & "   `cta_banco1` VARCHAR( 15 ) NOT NULL DEFAULT  ' ',  `cbanco` VARCHAR( 60 ) NOT NULL DEFAULT  ' '," _
                              & "PRIMARY KEY (`nit`)) ENGINE=MyISAM DEFAULT CHARSET=latin1;"
        Try
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        myCommand.CommandText = "INSERT INTO " & bd & ".`terceros` VALUES ('0', '0', ' [  SIN NIT  ]', ' ', 'OTROS', 'natural', '(ninguna)', '', '20', '20001', '(ninguno)', '(ninguno)', '(ninguno)', '(ninguno)', '(ninguno)', '', '', '', '', 0, 0, 'SI', 'NO', 'NO', 'NO', '', 'NO', '0', '0', '0', '0', ' ', ' '); "
        Try
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        'TABLA COBDPEN 
        myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".cobdpen (" _
        & "`doc` varchar(30) NOT NULL,`tipo` varchar(4) NOT NULL,`num` bigint(20) NOT NULL,`descrip` varchar(40) NOT NULL,`tipafec` varchar(4) NOT NULL,`clasaju` char(1) NOT NULL,`nitc` varchar(15) NOT NULL,`nomnit` varchar(100) NOT NULL,`nitcod` varchar(15) NOT NULL,`nitv` varchar(15) NOT NULL," _
        & "`fecha` date NOT NULL,`vmto` int(11) NOT NULL,`concepto` varchar(100) NOT NULL,`subtotal` double NOT NULL,`descto` double NOT NULL,`ret` double NOT NULL,`iva` decimal(10,2) NOT NULL,`v_viva` double NOT NULL,`total` double NOT NULL,`ctasubtotal` varchar(15) NOT NULL,`ctaret` varchar(15) NOT NULL," _
        & "`ctaiva` varchar(15) NOT NULL,`ctatotal` varchar(15) NOT NULL,`ccosto` varchar(15) NOT NULL,`otroimp` char(1) NOT NULL,`retiva` double NOT NULL, `ctaretiva` varchar(15) NOT NULL,`retica` double NOT NULL,`ctaretica` varchar(15) NOT NULL,`pagado` double NOT NULL,`rcpos` varchar(10) NOT NULL,`fechpos` date NOT NULL," _
        & "`vpos` double NOT NULL,`tasa` double NOT NULL,`moneda` varchar(2) NOT NULL,`monloex` char(1) NOT NULL,`estado` varchar(2) NOT NULL,`salmov` char(1) NOT NULL,`pagare` varchar(15) NOT NULL, PRIMARY KEY  (`doc`));"
        myCommand.ExecuteNonQuery()
        'TABLA CTAS POR PAGAR
        myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".ctas_x_pagar (" _
        & "`doc` varchar(15) NOT NULL,`tipo` varchar(4) NOT NULL,`num` bigint(20) NOT NULL,`doc_ext` varchar(50) NOT NULL,`descrip` varchar(40) NOT NULL,`tipafec` varchar(4) NOT NULL,`clasaju` char(1) NOT NULL,`nitc` varchar(15) NOT NULL,`nomnit` varchar(100) NOT NULL,`nitcod` varchar(15) NOT NULL," _
        & "`fecha` date NOT NULL,`vmto` int(11) NOT NULL,`concepto` varchar(100) NOT NULL,`subtotal` double NOT NULL,`descto` double NOT NULL,`ret` double NOT NULL,`iva` decimal(10,2) NOT NULL,`v_viva` double NOT NULL,`total` double NOT NULL,`ctasubtotal` varchar(15) NOT NULL,`ctaret` varchar(15) NOT NULL," _
        & "`ctaiva` varchar(15) NOT NULL,`ctatotal` varchar(15) NOT NULL,`ccosto` varchar(15) NOT NULL,`otroimp` char(1) NOT NULL,`retiva` double NOT NULL,`ctaretiva` varchar(15) NOT NULL,`retica` double NOT NULL,`ctaretica` varchar(15) NOT NULL,`pagado` double NOT NULL,`rcpos` varchar(10) NOT NULL,`fechpos` date NOT NULL," _
        & "`vpos` double NOT NULL,`tasa` double NOT NULL,`moneda` varchar(2) NOT NULL,`monloex` char(1) NOT NULL,`estado` varchar(2) NOT NULL,`salmov` char(1) NOT NULL,`pagare` varchar(15) NOT NULL, PRIMARY KEY  (`doc`));"
        myCommand.ExecuteNonQuery()
        'IMPUESTOS
        CreateImpuestos(bd)
        ''ANTICIPOS
        'TablaAnticipos(bd)

        'GERENCIAL
        myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".`par_analisis` ( " _
          & " `num` INT( 11 ) NOT NULL , " _
          & " `detalle` VARCHAR( 30 ) NOT NULL , " _
          & " `cuenta1` VARCHAR( 15 ) NOT NULL , " _
          & " `cuenta2` VARCHAR( 15 ) NOT NULL , " _
           & "`cuenta3` VARCHAR( 15 ) NOT NULL , " _
           & " `cuenta4` VARCHAR( 15 ) NOT NULL , " _
           & "  `cuenta5` VARCHAR( 15 ) NOT NULL , " _
           & "  `cuenta6` VARCHAR( 15 ) NOT NULL , " _
           & "  `cuenta7` VARCHAR( 15 ) NOT NULL , " _
           & "  `cuenta8` VARCHAR( 15 ) NOT NULL , " _
           & "  `cuenta9` VARCHAR( 15 ) NOT NULL , " _
           & "  `cuenta10` VARCHAR( 15 ) NOT NULL " _
           & " );"
        myCommand.ExecuteNonQuery()

        ''************** TABLA CONCEPTO COMICIONABLES
        myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".`concomi` (`codcon` INT NOT NULL AUTO_INCREMENT PRIMARY KEY ,`concepto` TEXT NOT NULL ,`porcomi` DECIMAL( 10, 2 ) NOT NULL) ENGINE = MYISAM ;"
        myCommand.ExecuteNonQuery()

    End Sub
    Public Sub Estetica(ByVal bd As String)

        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "CREATE TABLE  IF NOT EXISTS " & bd & ".`citas` (" _
             & " `num` BIGINT NOT NULL , " _
             & " `nitc` VARCHAR( 15 ) NOT NULL , " _
             & " `nita` VARCHAR( 15 ) NOT NULL , " _
             & " `servicio` VARCHAR( 200 ) NOT NULL , " _
             & " `fecha` DATE NOT NULL , " _
             & " `hora` TIME NOT NULL , " _
             & " `observ` TEXT NOT NULL , " _
             & " `nitr` VARCHAR( 15 ) NOT NULL , " _
             & " `estado` VARCHAR( 15 ) NOT NULL , " _
            & " PRIMARY KEY (  `num` ) " _
            & " ) ENGINE = INNODB; "
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = " CREATE TABLE  IF NOT EXISTS " & bd & ".`metas_x_area` (" _
             & "`codigo` VARCHAR( 20 ) NOT NULL , " _
             & "`area` VARCHAR( 60 ) NOT NULL , " _
             & "`tope` DOUBLE NOT NULL , " _
             & "`tipcom` VARCHAR( 15 ) NOT NULL , " _
             & "`valcom` DOUBLE NOT NULL , " _
             & "`fini` DATE NOT NULL , " _
             & "`ffin` DATE NOT NULL , " _
             & "`rango` VARCHAR( 20 ) NOT NULL , " _
             & "`felab` DATE NOT NULL , " _
             & "PRIMARY KEY (  `codigo` ) " _
            & ") ENGINE = INNODB; "
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = " CREATE TABLE  IF NOT EXISTS " & bd & ".`grupo_flia` (" _
         & " `codgrupo` VARCHAR( 15 ) NOT NULL , " _
         & " `nombre` VARCHAR( 200 ) NOT NULL , " _
         & " `pordes` DOUBLE NOT NULL , " _
         & " `nitc` VARCHAR( 15 ) NOT NULL , " _
         & " `edad` DATE NOT NULL, " _
         & " PRIMARY KEY (  `codgrupo` ) " _
         & " ) ENGINE = INNODB; "
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

    End Sub
    Public Sub MedioMag(ByVal bd As String)


        Try ' CTAS FORMATOS
            myCommand.Parameters.Clear()
            myCommand.CommandText = " CREATE TABLE IF NOT EXISTS " & bd & ".`cta_conc` (" _
          & " `codfor` varchar(5) NOT NULL, " _
          & " `codcon` varchar(5) NOT NULL, " _
          & " `cuenta` varchar(10) NOT NULL, " _
          & " `mov` varchar(2) NOT NULL default 'sl' " _
          & " ) ENGINE=InnoDB DEFAULT CHARSET=latin1;  "
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Try 'FORMATOS
            myCommand.Parameters.Clear()
            myCommand.CommandText = " CREATE TABLE IF NOT EXISTS " & bd & ".`conceptos` (" _
          & "  `codfor` varchar(5) NOT NULL, " _
          & "  `codcon` varchar(5) NOT NULL, " _
          & "  `descr` varchar(200) NOT NULL, " _
          & "  `tope` double NOT NULL, " _
          & "  KEY `codfor` (`codfor`) " _
        & "  ) ENGINE=InnoDB DEFAULT CHARSET=latin1; "
            myCommand.ExecuteNonQuery()


            myCommand.Parameters.Clear()
            myCommand.CommandText = "insert  into `conceptos`(`codfor`,`codcon`,`desc`,`tope`) " _
            & " values ('1001','5001','Salarios, Prestaciones y demas pagos laborales',0),('1001','5002','Honorarios',50000),('1001','5003','Comisiones',0),('1001','5004','Servicios',0),('1001','5005','Arrendamientos',0),('1001','5006','Intereses y rendimientos financieros',0),('1001','5007','Compra de activos movibles',0),('1001','5008','Compra de activos fijos',0),('1001','5010','Aportes parafiscales Sena, Bienestar Familiar y Caja de Compensacion',0),('1001','5011','Aportes Parafiscales a las Empresas Promotoras de Salud EPS y aportes al sistema de riesgos profesionales (incluidos los aportes del  trabajador)',0),('1001','5012','Aportes obligatorios de pensiones efectuados al ISS y a los Fondos de Pensiones (incluidos los aportes del trabajador)',0),('1001','5013','Donaciones en dinero',0),('1001','5014','Donaciones en otros activos',0),('1001','5015','Impuestos',0),('1001','5016','Demas costos y deducciones ',0),('1001','5018','Importe de primas de reaseguros pagados o abonados en cuentas',0),('1001','5019','Amortizaciones realizadas durante el aÃ±o',0),('1001','5020','Compra de activos fijos sobre los cuales solicito deducciÃ³n ',0),('1001','5022','Pensiones',0),('1001','5023','Cuenta al exterior por asistencia tecnica',0),('1001','5024','Cuenta al exterior por marcas',0),('1001','5025','Cuenta al exterior por patentes',0), " _
            & "('1001','5026','Cuenta al exterior por regalias',0),('1001','5027','Cuenta al exterior por servicios tecnicos',0),('1001','5028','el valor acumulado de la devolucion de pagos o abonos en cuenta y retenciones correspondientes a operaciones de aÃ±os anteriores',0),('1001','5029','Cargos diferidos y/o gastos pagados por anticipado por compras',0),('1001','5030','Cargos diferidos y/o gastos pagados por anticipado por Honorarios',0),('1001','5031','Cargos diferidos y/o gastos pagados por anticipado por Compras',0),('1001','5032','Cargos diferidos y/o gastos pagados por anticipado por Servicios',0),('1001','5033','Cargos diferidos y/o gastos pagados por anticipado por Arrendamientos',0),('1001','5034','Cargos diferidos y/o gastos pagados por anticipado por intereses y rendimientos financieros',0),('1001','5035','Cargos diferidos y/o gastos pagados por anticipado por Otros Conceptos',0),('1001','5036','Inversiones en control y mejoramiento del medio ambiente por Compras',0),('1001','5037','Inversiones en control y mejoramiento del medio ambiente por Honorarios',0),('1001','5038','Inversiones en control y mejoramiento del medio ambiente por Comisiones',0),('1001','5039','Inversiones en control y mejoramiento del medio ambiente por Servicios',0),('1001','5040','Inversiones en control y mejoramiento del medio ambiente por Arrendamientos',0), " _
            & "('1001','5041','Inversiones en control y mejoramiento del medio ambiente efectuada por Intereses y Rendimientos Financieros',0),('1001','5042','Inversiones en control y mejoramiento del medio ambiente por Otros Conceptos',0),('1001','5043','Participaciones o dividendos pagados o abonados en cuenta en calidad de exigibles',0),('1001','5044','El pago por loterÃ­as, rifas, apuestas y similares',0),('1001','5045','Retencion sobre ingresos de tarjetas debito y credito',0),('1001','5046','EnajenaciÃ³n de activos fijos de personas naturales ante oficinas de transito y ',0),('1001','5047','Importes siniestros por lucro cesante pagados o abonados en cuenta',0),('1001','5048','Importe siniestros por daÃ±o emergente pagados  o abonados en cuenta',0),('1001','5049','Autorretenciones por ventas',0),('1001','5050','Autorretenciones por servicios',0),('1001','5051','Autorretenciones por rendimientos financieros',0),('1001','5052','Otras Autorretenciones',0),('1001','5053','Retenciones practicas a titulo de timbre',0),('1001','5054','La devolucion de retenciones a titulo de impuestos de timbre, correspondiente a operaciones de aÃ±os anteriores',0),('1001','5055','Viaticos no considerados ingresos para trabajador',0),('1001','5056','Gastos de representacion no considerados como ingresos para persona',0),('1001','5057','Amortizaciones realizadas durante el aÃ±o por cargos diferidos impuestos al patrimonio',0),('1001','5058','Aportes, tasas y contribuciones  efectivamente pagados',0),('1001','5059','El pago o abono en cuenta a cada uno de los cooperados del valor del fondo de proteccion de aportes creado con el remanente, en el concepto',0),('1001','5060','Redencion de inversiones en lo que corresponde al reembolso del capital',0),('1003','1301','Retenciones por salarios, prestaciones y demas pagos laborales',0),('1003','1302','Retenciones por ventas',0),('1003','1303','Retenciones por Servicios',0),('1003','1304','Retenciones por Honorarios',0),('1003','1305','Retenciones por Comisiones',0),('1003','1306','Retenciones por Intereses y Rendimientos Financieros',0),('1003','1307','Retenciones por Arrendamiento',0),('1003','1308','Otras retenciones por otros conceptos',0),('1003','1309','Retencion en la fuente en el impuesto de ventas',0),('1003','1310','Retencion por dividendos y participaciones',0),('1003','1311','Retencion por enajenaciÃ³n de activos  fijos de personas naturales ante oficinas de transito y otras entidades autorizadas',0),('1003','1312','Retencion por ingresos de tarjeta debito y credito',0),('1003','1313','Retencion por loterias, rifas, apuestas y similares',0),('1003','1314','Retencion por Impuesto de Timbre',0),('1007','4001','Ingresos brutos operaciones',0),('1007','4002','Ingresos no operacionales diferentes de intereses y rendimientos financieros',0),('1007','4003','Ingresos por intereses y rendimientos financieros',0),('1007','4004','Ingresos por intereses correspondientes a creditos hipotecarios',0),('1008','1315','Cuentas por Cobrar-Clientes',0),('1008','1316','Cuentas por cobrar compaÃ±ias accionistas, socios y compaÃ±ias vinculadas',0),('1008','1317','Otras cuentas por cobrar',0),('1008','1318','Saldo fiscal provicion de cartera',0),('1009','2201','Pasivo con proveedores',0),('1009','2202','Cuentas por pagar a casa matriz, compaÃ±ias vinculadas, socios y accionistas',0),('1009','2203','Obligaciones con el sector financiero',0),('1009','2204','Pasivos por impuestos, gravamenes y tasas',0),('1009','2205','Pasivos laborales',0),('1009','2206','Otros pasivos',0),('1009','2207','Saldo del pasivo por el calculo actuarial',0),('1009','2208','Pasivos respaldados en documento de fecha cierta',0),('1009','2209','Pasivos exclusivos de la compaÃ±Ã­a de seguros',0),('1011','8001','Ingresos no constitutivos - Dividendos y particiones',0),('1011','8002','Ingresos no constitutivos - Rendimientos financieros',0),('1011','8004','Ingresos no constitutivos - Prima colocaciÃ³n de acciones, cuotas o partes de interes social',0),('1011','8005','Ingresos no constitutivos - Utilidad enajenacion de acciones',0),('1011','8006','Ingresos no constitutivos - Utilidad enajenacion derivados valores',0),('1011','8007','Ingresos no constitutivos - CapitalizaciÃ³n Revalorizacion del patrimonio',0),('1011','8008','Ingresos no constitutivos - Indemnizaciones seguro daÃ±o',0),('1011','8009','Ingresos no constitutivos - IndemnizaciÃ³n destrucciÃ³n o renovaciÃ³n de cultivos  control plagas',0),('1011','8010','Ingresos no constitutivos - Aportes estatales, sobretasas e impuestos financiacion transporte publico masivo de pasajeros',0),('1011','8011','Ingresos no constitutivos - Ingresos organizaciones regionales TV y audiovisuales de la CNTV',0),('1011','8012','Ingresos no constitutivos - Distribucion utilidades o reservas acciones o cuotas de interÃ©s social',0),('1011','8013','Ingresos no constitutivos - Ingresos liberaciÃ³n de la reserva, constituida por deduccuion cuotas o depreciaciÃ³n superior al valor',0),('1011','8014','Ingresos no constitutivos - Incentivo capacitaciÃ³n rural, (ICR)',0),('1011','8015','Ingresos no constitutivos - Utilidad venta casa o apto habitacion',0),('1011','8016','Ingresos no constitutivos - Retribuccion como recompensa',0),('1011','8017','Ingresos no constitutivos - Utilidad enajenaciÃ³n voluntaria de bienes expropiados',0),('1011','8018','Ingresos no constitutivos - Utilidad primas de localizacion y vivienda',0),('1011','8019','Ingresos no constitutivos - Aportes obligatorios a fondos de pensiones',0),('1011','8020','Ingresos no constitutivos - Aportes voluntarios a fondos de pensiones',0),('1011','8021','Ingresos no constitutivos - Ahorros largo plazo fomento de la construcciÃ³n',0),('1011','8022','Ingresos no constitutivos - Aportes a fondos de cesantias',0),('1011','8023','Ingresos no constitutivos - Subsidios otorgadas programa Agro Ingreso Seguro - AIS',0),('1011','8024','Ingresos no constitutivos - Dividendos y particiones socios, accionistas o asociados de empresas editoriales',0),('1011','8025','Ingresos no constitutivos - DistribuciÃ³n de utilidades  por liquidaciÃ³n de sociedades limitadas ',0),('1011','8026','Ingresos no constitutivos - Donaciones partidos, movimientos y campaÃ±as politicas',0),('1011','8027','Ingresos no constitutivos - Valor solicitado por la utilidad obtenida en la enajenaciÃ³n de bienes inmuebles, en el concepto',0),('1011','8028','Ingresos no constitutivos - Valor solicitado por la Utilidad en procesos de capitalizacion, en el concepto',0),('1011','8029','Ingresos no constitutivos - Valor solicitado por los ingresos recibidos para ser destinados al desarrollo de proyectos calificados como carÃ¡cter cientÃ­fico, tecnolÃ³gico o inversiÃ³n, en el concepto',0),('1011','8102','Rentas exentas por Ley Paez',0),('1011','8103','Rentas exentas eje cafetero',0),('1011','8104','Rentas exentas por energia electrica con recurso eÃ³licos, biomasa o residuos agricolas',0),('1011','8105','Rentas exentas por servicios de ecoturismo',0),('1011','8106','Rentas exentas por aprovechamientos de nuevas plantaciones forestales',0),('1011','8109','Rentas exentas por la prestacion servicio fluvial',0),('1011','8110','Rentas exentas por nuevos contratos de arrendamiento financiero',0),('1011','8111','Rentas exentas por enajenaciones predios utilidad publicas',0),('1011','8115','Rentas exentas de empresas editoriales',0),('1011','8116','Rentas exentas en procesos de titularizacion de cartera hipotecarias y de los bonos hipotecarios',0),('1011','8117','Rentas exentas por incentivos a la financiaciÃ³n de vivienda de interÃ©s social',0),('1011','8118','Rentas exentas por asfaltos',0),('1011','8120','Rentas exentas por aplicacion de algun convenio para evitar  la doble tributacion',0),('1011','8121','Rentas exentas por derechos de autor, articulo 28 Ley 98 de 1993',0),('1011','8123','Rentas exentas por Dividendos y particiones de socios y accionistas, Ley Paez, Inc..2, articulo 288 Estatuto Tributario',0),('1011','8124','Rentas exentas por incentivos para la construcciÃ³n de vivienda para arrendar, articulo 41 Ley 820 de 2003',0),('1011','8125','Rentas exentas por Interes, comisiones y pagos por deuda publica externa, articulo 218  Estatuto Tributario',0),('1011','8126','Rentas exentas por donaciones Protocolo Montreal, articulo 32, ley 488 de 1998',0),('1011','8127','Rentas exentas por InversiÃ³n en forestaciÃ³n, aserrios y arboles maderables',0),('1011','8128','Rentas exentas en proyectos industriales en Zonas especiales EconÃ³micas de Exportacion',0),('1011','8129','Rentas exentas por renta liquida generada aprovechamiento nuevos cultivos tardÃ­o rendimiento',0),('1011','8130','Rentas exentas por empresas asociativas de trabajo, Ley 10  de 1991',0),('1011','8131','Rentas exentas por nuevos productos medicinales elaborados en Colombia',0),('1011','8132','Rentas exentas por nuevos software elaborado en Colombia',0),('1011','8133','Rentas exentas servicio hoteles nuevos',0),('1011','8134','Rentas servicio de hoteles remodelados o ampliados',0),('1011','8135','Rentas exentas por juegos de suerte y azar',0),('1011','8136','Rentas exentas por licores y alcoholes',0),('1011','8137','Rentas exentas por pagos Laborales',0),('1011','8138','Rentas exentas por la venta de certificados de emision de bioxido de carbono protocolo de Kyoto',0),('1011','8200','DeducciÃ³n por inversiÃ³n en activos fijos reales productivos',0),('1011','8202','DeducciÃ³n por inversiones realizadas en control y mejoramiento del medio ambiente',0),('1011','8203','DeducciÃ³n por inversiones en nuevas plantaciones, riegos, pozos y silos',0),('1011','8204','DeducciÃ³n por inversiones en desarrollo cientifico y tecnologico',0),('1011','8205','DeducciÃ³n por provisiones para deudas de difÃ­cil cobro y deudas perdidas',0),('1011','8206','DeducciÃ³n por depreciaciÃ³n, amortizaciones y agotamiento ',0),('1011','8207','DeducciÃ³n por salarios, prestaciones sociales y demas pagos laborales',0),('1011','8208','DeducciÃ³n por pagos a casa matriz',0),('1011','8209','DeducciÃ³n por pagos al exterior',0),('1011','8210','El DeducciÃ³n por en la enajenaciÃ³n de activos fijos',0),('1011','8211','El valor solicitado como deducciÃ³n por concepto del gravamen a los movimientos financieros',0),('1011','8212','El valor solicitado como deducciÃ³n por agotamiento en explotaciÃ³n de hidrocarburos ',0),('1011','8214','El valor solicitado como deducciÃ³n para amortizacion en el sector agropecuario, articulo 158 Estatuto Tributario',0),('1011','8215','El valor solicitado como deducciÃ³n por intereses prestamos vivienda, articulo 119 estatuto tributario',0),('1011','8217','El valor solicitado como deducciÃ³n por donaciÃ³n o inversiÃ³n en ProducciÃ³n cinematogrÃ¡ficas articulo 16, Ley 814  de 2003',0),('1011','8218','El valor solicitado como proteccion, mantenimiento y conservacion de muebles e inmuebles de interes cultural, articulo 14 ley 1185  de 2008',0),('1011','8219','DeducciÃ³n por donacion a entidades No contribuyentes, numeral 1 art, 125 ET',0),('1011','8220','DeducciÃ³n por donaciÃ³n a asociaciones, corporaciones y fundaciones sin animo de lucro, numeral  2.art. 125 ET ',0),('1011','8221','DeducciÃ³n por donaciÃ³n a fondos mixtos la promociÃ³n cultural, deportes, artes, ICBF, numeral 2 art.125 E.T',0),('1011','8222','DeducciÃ³n por donaciÃ³n a Corporacion General Gustavo Matamoros D\' Costa  y demas fundaciones protecciÃ³n derechos humanos',0),('1011','8223','DeducciÃ³n por donaciÃ³n a organismo deportes aficionados, inciso 2, art.126-2 ET',0),('1011','8224','DeducciÃ³n por donaciÃ³n a organismos deportivos y recreativos o culturales sin animo de lucro, Inciso 3, art. 126-2 ET',0),('1011','8225','DeducciÃ³n por donaciÃ³n a Red Nacional de Bibliotecas Publicas y Biblioteca Nacional, paragrafo, art.125 ET',0),('1011','8226','DeducciÃ³n por donaciÃ³n al Fondo Seguro Obligatorio Accidentes de Transito - FONSAT',0),('1011','8227','DeducciÃ³n por concepto de regalÃ­as del pais',0),('1011','8228','DeducciÃ³n por las reparaciones locativas inmuebles',0),('1011','8229','DeducciÃ³n por inversiones realizadas en investigaciones cientificas o tecnologicas',0),('1011','8230','DeducciÃ³n por inversiÃ³n en librerÃ­as ',0),('1011','8231','DeducciÃ³n por inversion en centros de reclusion',0),('1011','8232','DeducciÃ³n por deduccion para adelantar proyecto agroindutrial',0),('1011','8233','DeducciÃ³n por impuestos pagados',0),('1011','8234','DeducciÃ³n de intereses, art. 117 ET',0),('1011','8235','DeducciÃ³n por contribuciones a carteras colectivas',0),('1011','8236','DeducciÃ³n por contratos leasing, art. 127-1 ET',0),('1011','8237','DeducciÃ³n por concepto de publicidad y propaganda',0),('1011','8238','DeducciÃ³n por provision individual cartera creditos y provision coeficiente riesgo, Paragrafo del art. 145 ET',0),('1011','8239','DeducciÃ³n por deudas perdidas o sin valor',0),('1011','8240','Valor solicitado como deduccion por perdida de activos',0),('1011','8241','DeducciÃ³n por aportes al Instituto Colombiano de Bienestar Familiar, ICBF',0),('1011','8242','DeducciÃ³n por aportes a cajas de compensacion familiar',0),('1011','8243','DeducciÃ³n por aportes al Servicio Nacional de Aprendizaje, SENA',0),('1011','8244','DeducciÃ³n por contribuciones a fondos de pensiones de jubilacion e invalidez',0),('1011','8245','DeducciÃ³n por cesantias efectivamente pagadas y o reconocidas al trabajador',0),('1011','8246','DeducciÃ³n por aportes a cesantias por los trabajadores independientes',0),('1011','8247','DeducciÃ³n por contribuciones parafiscales agropecuarias de productores a fondos de estabilizaciÃ³n, Ley 101 de 1993 ',0),('1011','8248','DeducciÃ³n por salarios, prestaciones sociales y demas pagos laborales, pagados a viudas y huÃ©rfanos de miembros FFAA , Heroes de la NaciÃ³n, y/o mujeres victimas de violencia',0),('1011','8249','DeducciÃ³n por salarios y prestaciones sociales de los trabajadores aprendices, Art. 189 Ley 115 de 1994',0),('1011','8250','DeducciÃ³n por salarios pagados, durante el cautiverio, a sus empleados victimas de secuestros',0),('1011','8255','DeducciÃ³n por concepto de alimentacion del trabajador y su familia o suminitros de alimentacion para los mismos',0),('1011','8256','DeducciÃ³n por el pago de estudios a trabajadores en instituciones de educacion superior',0),('1011','8257','DeducciÃ³n por factor especial agotamiento en explotacion de hirdrocarburos, art 166 ET',0),('1011','8258','DeducciÃ³n por amortizacion inversiones en exploracion de gases, y minerales distintos de hidrocarburos',0),('1011','8259','DeducciÃ³n tasas y contribuciones fiscales pagadas',0),('1011','8260','DeducciÃ³n por impuestos, regalias y contribuciones pagados por organismos descentralizados',0),('1011','8261','DeducciÃ³n provision pago futuras pensiones',0),('1011','8262','DeducciÃ³n sumas pagadas y prestaciones trabajadores discapacidad inferior 25 %',0),('1011','8263','DeducciÃ³n por salarios y prestaciones trabajadores discapacidad inferior 25%',0),('1011','8264','DeducciÃ³n inversiones transporte aÃ©reo en zonas apartadas del pais',0),('1012','1110','Saldo a 31 de diciembre de las cuentas corrientes y7o ahorro que posean en el pais',0),('1012','1115','El valor total del saldo de las cuentas corrientes y/o ahorro poseidas en el exterior',0),('1012','1200','El valor patrimonial de los bonos poseidos a 31 de diciembre',0),('1012','1201','El valor patrimonial de los certificados de deposito poseidos a 31 de diciembre',0),('1012','1202','Valor patrimonial de los titulos poseidos a 31 de diciembre ',0),('1012','1203','Valor patrimonial de los derechos fiduciarios poseidos a 31 de diciembre',0),('1012','1204','Valor patrimonial de las demas inversiones poseidas a 31 de diciembre',0),('1012','1205','Acciones o aportes poseidos en sociedades',0),('1017','4040','Ingresos a traves de contratos de mandato o de administraciÃ³n delegada',0),('1018','1340','Cuentas por cobrar en contratos de mandato o de administraciÃ³n delegada',0),('1025','1001','Utilidad antes de impuestos vs renta liquida',0),('1025','1002','Utilidad antes de impuestos vs perdida liquida',0),('1025','1003','Perdida del ejercicio vs renta liquida',0),('1025','1004','Perdida del ejercicio vs perdida liquida',0),('1025','1005','Patrimonio contable vs patrimonio liquido',0),('1025','1006','Patrimonio contable negativo vs patrimonio liquido',0),('1026','1','Prestamos comerciales',1000),('1026','2','Prestamos de consumo',10000),('1026','3','Prestamos hipotecarios',30000),('1026','4','Otros prestamos',0),('1027','2240','Pasivos en contratos de mandato o de administraciÃ³n delegada',0),('1034','1000','Activo corriente',0),('1034','1011','Activo no corriente',0),('1034','2000','Pasivo corriente',0),('1034','2001','Pasivo no corriente',0),('1034','2002','Interes minoritario de Balance',0),('1034','3000','Patrimonio',0),('1034','4100','Ingresos Operacionales',0),('1034','6000','Costos de Ventas',0),('1034','5100','Gastos operacionales de administracion',0),('1034','5200','Gastos operacionales de Ventas',0),('1034','4200','Otros ingresos no operacionales',0),('1034','5300','Otros egresos no operacionales',0),('1034','5301','Utilidad antes de impuestos de renta',0),('1034','5302','Interes minoratorio de resultados',0),('1034','5304','Utilidad neta',0),('1034','5305','Impuestos de renta',0),('1034','5306','Perdida neta',0),('1034','5307','Interes minoratorio de resultados (perdida)',0),('1043','5001','Salarios, Prestaciones y demas pagos laborales',0),('1043','5002','Honorarios',0),('1043','5003','Comisiones',0),('1043','5004','Servicios',0),('1043','5005','Arrendamientos',0),('1043','5006','Intereses y rendimientos financieros',0),('1043','5007','Compra de activos movibles',0),('1043','5008','Compra de activos fijos',0),('1043','5010','Aportes parafiscales Sena, Bienestar Familiar y Caja de Compensacion',0),('1043','5011','Aportes Parafiscales a las Empresas Promotoras de Salud EPS y aportes al sistema de riesgos profesionales (incluidos los aportes del  trabajador)',0),('1043','5012','Aportes obligatorios de pensiones efectuados al ISS y a los Fondos de Pensiones (incluidos los aportes del trabajador)',0),('1043','5013','Donaciones en dinero',0),('1043','5014','Donaciones en otros activos',0),('1043','5015','Impuestos',0),('1043','5016','Demas costos y deducciones ',0),('1043','5018','Importe de primas de reaseguros pagados o abonados en cuentas',0)," _
            & "('1043','5019','Amortizaciones realizadas durante el aÃ±o',0),('1043','5020','Compra de activos fijos sobre los cuales solicito deducciÃ³n ',0),('1043','5022','Pensiones',0),('1043','5023','Cuenta al exterior por asistencia tecnica',0),('1043','5024','Cuenta al exterior por marcas',0),('1043','5025','Cuenta al exterior por patentes',0),('1043','5026','Cuenta al exterior por regalias',0),('1043','5027','Cuenta al exterior por servicios tecnicos',0),('1043','5028','el valor acumulado de la devolucion de pagos o abonos en cuenta y retenciones correspondientes a operaciones de aÃ±os anteriores',0),('1043','5029','Cargos diferidos y/o gastos pagados por anticipado por compras',0),('1043','5030','Cargos diferidos y/o gastos pagados por anticipado por Honorarios',0),('1043','5031','Cargos diferidos y/o gastos pagados por anticipado por Compras',0),('1043','5032','Cargos diferidos y/o gastos pagados por anticipado por Servicios',0),('1043','5033','Cargos diferidos y/o gastos pagados por anticipado por Arrendamientos',0),('1043','5034','Cargos diferidos y/o gastos pagados por anticipado por intereses y rendimientos financieros',0),('1043','5035','Cargos diferidos y/o gastos pagados por anticipado por Otros Conceptos',0),('1043','5036','Inversiones en control y mejoramiento del medio ambiente por Compras',0),('1043','5037','Inversiones en control y mejoramiento del medio ambiente por Honorarios',0),('1043','5038','Inversiones en control y mejoramiento del medio ambiente por Comisiones',0),('1043','5039','Inversiones en control y mejoramiento del medio ambiente por Servicios',0),('1043','5040','Inversiones en control y mejoramiento del medio ambiente por Arrendamientos',0),('1043','5041','Inversiones en control y mejoramiento del medio ambiente efectuada por Intereses y Rendimientos Financieros',0),('1043','5042','Inversiones en control y mejoramiento del medio ambiente por Otros Conceptos',0),('1043','5043','Participaciones o dividendos pagados o abonados en cuenta en calidad de exigibles',0),('1043','5044','El pago por loterÃ­as, rifas, apuestas y similares',0),('1043','5045','Retencion sobre ingresos de tarjetas debito y credito',0),('1043','5046','EnajenaciÃ³n de activos fijos de personas naturales ante oficinas de transito y ',0),('1043','5047','Importes siniestros por lucro cesante pagados o abonados en cuenta',0),('1043','5048','Importe siniestros por daÃ±o emergente pagados  o abonados en cuenta',0),('1043','5049','Autorretenciones por ventas',0),('1043','5050','Autorretenciones por servicios',0),('1043','5051','Autorretenciones por rendimientos financieros',0),('1043','5052','Otras Autorretenciones',0),('1043','5053','Retenciones practicas a titulo de timbre',0),('1043','5054','La devolucion de retenciones a titulo de impuestos de timbre, correspondiente a operaciones de aÃ±os anteriores',0),('1043','5055','Viaticos no considerados ingresos para trabajador',0),('1043','5056','Gastos de representacion no considerados como ingresos para persona',0),('1043','5057','Amortizaciones realizadas durante el aÃ±o por cargos diferidos impuestos al patrimonio',0),('1043','5058','Aportes, tasas y contribuciones  efectivamente pagados',0),('1043','5059','El pago o abono en cuenta a cada uno de los cooperados del valor del fondo de proteccion de aportes creado con el remanente, en el concepto',0),('1043','5060','Redencion de inversiones en lo que corresponde al reembolso del capital',0),('1045','4010','Ingresos de consorcios y uniones temporales',0),('1046','5001','Salarios, Prestaciones y demas pagos laborales',0),('1046','5002','Honorarios',0),('1046','5003','Comisiones',0),('1046','5004','Servicios',0),('1046','5005','Arrendamientos',0),('1046','5006','Intereses y rendimientos financieros',0),('1046','5007','Compra de activos movibles',0),('1046','5008','Compra de activos fijos',0),('1046','5010','Aportes parafiscales Sena, Bienestar Familiar y Caja de Compensacion',0),('1046','5011','Aportes Parafiscales a las Empresas Promotoras de Salud EPS y aportes al sistema de riesgos profesionales (incluidos los aportes del  trabajador)',0),('1046','5012','Aportes obligatorios de pensiones efectuados al ISS y a los Fondos de Pensiones (incluidos los aportes del trabajador)',0),('1046','5013','Donaciones en dinero',0),('1046','5014','Donaciones en otros activos',0),('1046','5015','Impuestos',0),('1046','5016','Demas costos y deducciones ',0),('1046','5018','Importe de primas de reaseguros pagados o abonados en cuentas',0),('1046','5019','Amortizaciones realizadas durante el aÃ±o',0),('1046','5020','Compra de activos fijos sobre los cuales solicito deducciÃ³n ',0),('1046','5022','Pensiones',0),('1046','5023','Cuenta al exterior por asistencia tecnica',0),('1046','5024','Cuenta al exterior por marcas',0),('1046','5025','Cuenta al exterior por patentes',0),('1046','5026','Cuenta al exterior por regalias',0),('1046','5027','Cuenta al exterior por servicios tecnicos',0),('1046','5028','el valor acumulado de la devolucion de pagos o abonos en cuenta y retenciones correspondientes a operaciones de aÃ±os anteriores',0),('1046','5029','Cargos diferidos y/o gastos pagados por anticipado por compras',0),('1046','5030','Cargos diferidos y/o gastos pagados por anticipado por Honorarios',0),('1046','5031','Cargos diferidos y/o gastos pagados por anticipado por Compras',0),('1046','5032','Cargos diferidos y/o gastos pagados por anticipado por Servicios',0),('1046','5033','Cargos diferidos y/o gastos pagados por anticipado por Arrendamientos',0),('1046','5034','Cargos diferidos y/o gastos pagados por anticipado por intereses y rendimientos financieros',0),('1046','5035','Cargos diferidos y/o gastos pagados por anticipado por Otros Conceptos',0),('1046','5036','Inversiones en control y mejoramiento del medio ambiente por Compras',0),('1046','5037','Inversiones en control y mejoramiento del medio ambiente por Honorarios',0),('1046','5038','Inversiones en control y mejoramiento del medio ambiente por Comisiones',0),('1046','5039','Inversiones en control y mejoramiento del medio ambiente por Servicios',0),('1046','5040','Inversiones en control y mejoramiento del medio ambiente por Arrendamientos',0),('1046','5041','Inversiones en control y mejoramiento del medio ambiente efectuada por Intereses y Rendimientos Financieros',0),('1046','5042','Inversiones en control y mejoramiento del medio ambiente por Otros Conceptos',0),('1046','5043','Participaciones o dividendos pagados o abonados en cuenta en calidad de exigibles',0),('1046','5044','El pago por loterÃ­as, rifas, apuestas y similares',0),('1046','5045','Retencion sobre ingresos de tarjetas debito y credito',0),('1046','5046','EnajenaciÃ³n de activos fijos de personas naturales ante oficinas de transito y ',0),('1046','5047','Importes siniestros por lucro cesante pagados o abonados en cuenta',0),('1046','5048','Importe siniestros por daÃ±o emergente pagados  o abonados en cuenta',0),('1046','5049','Autorretenciones por ventas',0),('1046','5050','Autorretenciones por servicios',0),('1046','5051','Autorretenciones por rendimientos financieros',0),('1046','5052','Otras Autorretenciones',0),('1046','5053','Retenciones practicas a titulo de timbre',0),('1046','5054','La devolucion de retenciones a titulo de impuestos de timbre, correspondiente a operaciones de aÃ±os anteriores',0),('1046','5055','Viaticos no considerados ingresos para trabajador',0),('1046','5056','Gastos de representacion no considerados como ingresos para persona',0),('1046','5057','Amortizaciones realizadas durante el aÃ±o por cargos diferidos impuestos al patrimonio',0),('1046','5058','Aportes, tasas y contribuciones  efectivamente pagados',0),('1046','5059','El pago o abono en cuenta a cada uno de los cooperados del valor del fondo de proteccion de aportes creado con el remanente, en el concepto',0),('1046','5060','Redencion de inversiones en lo que corresponde al reembolso del capital',0),('1048','4050','Ingresos en contratos de exploraciÃ³n y explotaciÃ³n minera',0),('1051','1350','Cuentas por cobrar en contratos de asociaciÃ³n de exploraciÃ³n y explotaciÃ³n minera',0),('1052','2250','Pasivos en contratos de asociaciÃ³n por exploraciÃ³n y explotaciÃ³n minera',0),('1056','5001','Salarios, Prestaciones y demas pagos laborales',0),('1056','5002','Honorarios',0),('1056','5003','Comisiones',0),('1056','5004','Servicios',0),('1056','5005','Arrendamientos',0),('1056','5006','Intereses y rendimientos financieros',0),('1056','5007','Compra de activos movibles',0),('1056','5008','Compra de activos fijos',0),('1056','5010','Aportes parafiscales Sena, Bienestar Familiar y Caja de Compensacion',0),('1056','5011','Aportes Parafiscales a las Empresas Promotoras de Salud EPS y aportes al sistema de riesgos profesionales (incluidos los aportes del  trabajador)',0),('1056','5012','Aportes obligatorios de pensiones efectuados al ISS y a los Fondos de Pensiones (incluidos los aportes del trabajador)',0),('1056','5013','Donaciones en dinero',0),('1056','5014','Donaciones en otros activos',0),('1056','5015','Impuestos',0),('1056','5016','Demas costos y deducciones ',0),('1056','5018','Importe de primas de reaseguros pagados o abonados en cuentas',0),('1056','5019','Amortizaciones realizadas durante el aÃ±o',0),('1056','5020','Compra de activos fijos sobre los cuales solicito deducciÃ³n ',0),('1056','5022','Pensiones',0),('1056','5023','Cuenta al exterior por asistencia tecnica',0),('1056','5024','Cuenta al exterior por marcas',0),('1056','5025','Cuenta al exterior por patentes',0),('1056','5026','Cuenta al exterior por regalias',0),('1056','5027','Cuenta al exterior por servicios tecnicos',0),('1056','5028','el valor acumulado de la devolucion de pagos o abonos en cuenta y retenciones correspondientes a operaciones de aÃ±os anteriores',0),('1056','5029','Cargos diferidos y/o gastos pagados por anticipado por compras',0),('1056','5030','Cargos diferidos y/o gastos pagados por anticipado por Honorarios',0),('1056','5031','Cargos diferidos y/o gastos pagados por anticipado por Compras',0),('1056','5032','Cargos diferidos y/o gastos pagados por anticipado por Servicios',0),('1056','5033','Cargos diferidos y/o gastos pagados por anticipado por Arrendamientos',0),('1056','5034','Cargos diferidos y/o gastos pagados por anticipado por intereses y rendimientos financieros',0),('1056','5035','Cargos diferidos y/o gastos pagados por anticipado por Otros Conceptos',0),('1056','5036','Inversiones en control y mejoramiento del medio ambiente por Compras',0),('1056','5037','Inversiones en control y mejoramiento del medio ambiente por Honorarios',0),('1056','5038','Inversiones en control y mejoramiento del medio ambiente por Comisiones',0),('1056','5039','Inversiones en control y mejoramiento del medio ambiente por Servicios',0),('1056','5040','Inversiones en control y mejoramiento del medio ambiente por Arrendamientos',0),('1056','5041','Inversiones en control y mejoramiento del medio ambiente efectuada por Intereses y Rendimientos Financieros',0),('1056','5042','Inversiones en control y mejoramiento del medio ambiente por Otros Conceptos',0),('1056','5043','Participaciones o dividendos pagados o abonados en cuenta en calidad de exigibles',0),('1056','5044','El pago por loterÃ­as, rifas, apuestas y similares',0),('1056','5045','Retencion sobre ingresos de tarjetas debito y credito',0),('1056','5046','EnajenaciÃ³n de activos fijos de personas naturales ante oficinas de transito y ',0),('1056','5047','Importes siniestros por lucro cesante pagados o abonados en cuenta',0),('1056','5048','Importe siniestros por daÃ±o emergente pagados  o abonados en cuenta',0),('1056','5049','Autorretenciones por ventas',0),('1056','5050','Autorretenciones por servicios',0),('1056','5051','Autorretenciones por rendimientos financieros',0),('1056','5052','Otras Autorretenciones',0),('1056','5053','Retenciones practicas a titulo de timbre',0),('1056','5054','La devolucion de retenciones a titulo de impuestos de timbre, correspondiente a operaciones de aÃ±os anteriores',0),('1056','5055','Viaticos no considerados ingresos para trabajador',0),('1056','5056','Gastos de representacion no considerados como ingresos para persona',0),('1056','5057','Amortizaciones realizadas durante el aÃ±o por cargos diferidos impuestos al patrimonio',0),('1056','5058','Aportes, tasas y contribuciones  efectivamente pagados',0),('1056','5059','El pago o abono en cuenta a cada uno de los cooperados del valor del fondo de proteccion de aportes creado con el remanente, en el concepto',0),('1056','5060','Redencion de inversiones en lo que corresponde al reembolso del capital',0),('1587','1370','Deudores en consorcios o uniones temporales',0),('1588','2270','Pasivos en consorcios o uniones temporales',0),('1647','4070','Ingresos recibidos para terceros',0);"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception

        End Try

        Try
            '-- Estructura de tabla para la tabla `formatos`
            '-- 
            myCommand.Parameters.Clear()
            myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".`formatos` (" _
          & " `codigo` varchar(10) NOT NULL, " _
          & " `descripcion` varchar(200) NOT NULL, " _
          & " `ver` int(11) NOT NULL, " _
          & " PRIMARY KEY  (`codigo`) " _
          & " ) ENGINE=InnoDB DEFAULT CHARSET=latin1; "
            myCommand.ExecuteNonQuery()


            myCommand.Parameters.Clear()
            myCommand.CommandText = "insert  into `formatos`(`codigo`,`descripcion`,`ver`) values " _
            & " ('1001','Pagos o abonos en cuenta y retenciones practicadas',8),('1003','Retenciones en la fuente que le practicaron',7), " _
            & "('1005','Impuesto a las ventas por pagar-Descontable',7),('1006','Impuesto a las ventas por pagar-Generado',7),('1007','Ingresos Recibidos',8),('1008','Saldo de cuentas por cobrar',7),('1009','Saldo de cuentas por Pagar',7),('1010','InformaciÃ³n de socios,  accionistas, comuneros y/o cooperados',8),('1011','InformaciÃ³n de las declaraciones Tributarias',6),('1012','InformaciÃ³n de declaraciones tributarias, acciones, inversiones en bonos tÃ­tulos valores y cuentas de ahorro y cuentas corrientes',7),('1013','InformaciÃ³n de Fideicomisos que administran',8),('1014','Pagos o abonos en cuenta y retenciones practicadas con recursos del fideicomiso',9),('1016','Pagos o abonos en cuenta en contratos de Mandato o AdministraciÃ³n Delegada',9),('1017','Ingresos Recibidos por contratos de Mandato o AdministraciÃ³n Delegada',8),('1018','Cuentas por Cobrar en contratos de Mandato o AdministraciÃ³n Delegada',8),('1019','Cuentas Corrientes y de ahorro, Titulares principales',8),('1020','Titulares principales en CDT',6),('1021','InformaciÃ³n De Inversiones En Carteras Colectivas, Fondos Mutuos De InversiÃ³n Y DemÃ¡s Fondos Administrados Por Sociedades Vigiladas Por La Superintendencia Financiera.',6),('1022','Ahorro Voluntario en Fondos de Pensiones',7), " _
            & " ('1023','Consumos con tarjetas de crÃ©dito y/o  tarjeta dÃ©bito',6),('1024','Ventas con Tarjetas de CrÃ©dito y/o Tarjetas dÃ©bito',6),('1025','Diferencias Contables y Fiscales',6),('1026','PrÃ©stamos bancarios otorgados',6),('1027','Cuentas por Pagar en contratos de Mandato o AdministraciÃ³n Delegada',8),('1028','InformaciÃ³n RegistradurÃ­a sobre personas fallecidas',7),('1032','Enajenaciones  de Bienes y Derechos a travÃ©s de Notarias',8),('1034','InformaciÃ³n de Estados Financieros consolidados-Grupos econÃ³micos',6),('1035','IdentificaciÃ³n de Subordinadas Nacionales',6),('1036','IdentificaciÃ³n de Subordinadas del Exterior',7),('1037','ElaboraciÃ³n de FacturaciÃ³n por LitÃ³grafos y TipÃ³grafos',7),('1038','InformaciÃ³n de sociedades creadas ( CÃ¡maras de Comercio)',6),('1039','Sociedades liquidadas',6),('1041','InformaciÃ³n de Bolsas de Valores',6),('1042','InformaciÃ³n de Comisionistas de Bolsas',7),('1043','Pagos o Abonos en cuenta y retenciones practicadas de consorcios y uniones temporales',8),('1045','InformaciÃ³n de ingresos recibidos por consorcios y uniones temporales',8),('1046','InformaciÃ³n de pagos o abonos en cuenta  de los contratos de asociaciÃ³n para exploraciÃ³n y explotaciÃ³n minera',8),('1048','InformaciÃ³n de ingresos recibidos de los contratos de asociaciÃ³n para exploraciÃ³n y explotaciÃ³n minera.',8),('1049','InformaciÃ³n de impuestos sobre las ventas (descontable) en contratos de exploraciÃ³n y explotaciÃ³n minera',7),('1050','InformaciÃ³n de impuestos sobre las ventas generado en contratos de exploraciÃ³n y explotaciÃ³n minera',7),('1051','Saldos de Cuentas por Cobrar a 31 de Diciembre en Contratos de AsociaciÃ³n para ExploraciÃ³n y ExplotaciÃ³n Minera',8),('1052','Saldos de Cuentas por Pagar a 31 de Diciembre en Contratos de AsociaciÃ³n para ExploraciÃ³n y ExplotaciÃ³n Minera',8),('1054','InformaciÃ³n del impuesto a las ventas descontable en contratos de mandato o de administraciÃ³n delegada',8),('1055','InformaciÃ³n del impuesto a las ventas generado en contratos de mandato o de administraciÃ³n delegada',8),('1056','Pagos o Abonos en cuenta y retenciones por secretarios generales que administran recursos del tesoro',8),('1058','Ingresos recibidos con cargo al  fideicomiso o patrimonio autonomo',9),('1585','Impuesto a las venas por pagar (Descontable) en consorcios y uniones temporales',1),('1586','Impuesto a las ventas por pagar (Generado) en consorcios y uniones temporales',1),('1587','Saldos de cuentas por cobrar al 31 de diciembre en consorcio o uniones temporales',1),('1588','Saldos de cuentas por pagar al 31 de diciembre en consorcio o uniones temporales',1),('1647','Ingresos recibidos para terceros',1);"
            myCommand.ExecuteNonQuery()

        Catch ex As Exception
        End Try

        'GUARDAR MOV FORMATO1001
        Try
            myCommand.CommandText = " CREATE TABLE  IF NOT EXISTS " & bd & ".`f1001` (" _
         & "`codcon` VARCHAR( 4 ) NOT NULL ," _
         & "`tdoc` VARCHAR( 2 ) NOT NULL , " _
         & "`num_id` VARCHAR( 20 ) NOT NULL , " _
         & "`dv` VARCHAR( 1 ) NOT NULL , " _
         & "`apell1` VARCHAR( 60 ) NOT NULL , " _
         & "`apell2` VARCHAR( 60 ) NOT NULL , " _
         & "`nom1` VARCHAR( 60 ) NOT NULL , " _
         & "`nom2` VARCHAR( 60 ) NOT NULL , " _
         & "`rsocial` VARCHAR( 400 ) NOT NULL , " _
         & "`dir` VARCHAR( 200 ) NOT NULL , " _
         & "`dpto` VARCHAR( 2 ) NOT NULL , " _
         & "`mcp` VARCHAR(5 ) NOT NULL , " _
         & "`pais` VARCHAR( 4 ) NOT NULL , " _
         & "`pagod` DOUBLE NOT NULL , " _
         & "`pagon` DOUBLE NOT NULL , " _
         & "`ivad` DOUBLE NOT NULL , " _
         & "`ivand` DOUBLE NOT NULL , " _
         & "`rtprac` DOUBLE NOT NULL , " _
         & "`rtasu` DOUBLE NOT NULL , " _
         & "`rtcomun` DOUBLE NOT NULL , " _
         & "`rtsimp` DOUBLE NOT NULL , " _
         & "`rtno` DOUBLE NOT NULL " _
        & ") ENGINE = INNODB; "
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        'FORMATO 1003
        Try
            myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".`f1003` (" _
          & "`codcon` varchar(4) NOT NULL, " _
          & "`tdoc` varchar(2) NOT NULL, " _
          & "`num_id` varchar(20) NOT NULL, " _
          & "`dv` char(1) NOT NULL, " _
          & "`apell1` varchar(100) NOT NULL, " _
          & "`apell2` varchar(100) NOT NULL, " _
          & "`nom1` varchar(100) NOT NULL, " _
          & "`nom` varchar(100) NOT NULL, " _
          & "`rsocial` varchar(400) NOT NULL, " _
          & "`dir` varchar(200) NOT NULL, " _
          & "`dpto` varchar(2) NOT NULL, " _
          & "`mcp` varchar(3) NOT NULL, " _
          & "`vartf` double NOT NULL, " _
          & "`tiprt` varchar(20) NOT NULL " _
          & ") ENGINE=InnoDB DEFAULT CHARSET=latin1; "
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        'FORMATO 1005
        Try
            myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".`f1005` (" _
          & " `codcon` VARCHAR(4) NOT NULL, " _
          & " `tdoc` VARCHAR(2) NOT NULL, " _
          & " `num_id` VARCHAR(20) NOT NULL, " _
          & "`dv` CHAR(1) NOT NULL, " _
          & "`apell1` VARCHAR(100) NOT NULL, " _
          & "`apell2` VARCHAR(100) NOT NULL, " _
          & "`nom1` VARCHAR(100) NOT NULL, " _
          & "`nom2` VARCHAR(100) NOT NULL, " _
          & "`rsocial` VARCHAR(400) NOT NULL, " _
          & "`impdes` DOUBLE NOT NULL, " _
          & "`ivaxdev` DOUBLE NOT NULL " _
          & ") ENGINE=INNODB DEFAULT CHARSET=latin1;"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        'FORMATO 1006
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".`f1006` (" _
          & "`codcon` VARCHAR(4) NOT NULL, " _
          & "`tdoc` VARCHAR(2) NOT NULL, " _
          & "`num_id` VARCHAR(20) NOT NULL, " _
          & "`dv` CHAR(1) NOT NULL, " _
          & "`apell1` VARCHAR(100) NOT NULL, " _
          & "`apell2` VARCHAR(100) NOT NULL, " _
          & "`nom1` VARCHAR(100) NOT NULL, " _
          & "`nom2` VARCHAR(100) NOT NULL, " _
          & "`rsocial` VARCHAR(400) NOT NULL, " _
          & "`impgen` DOUBLE NOT NULL, " _
          & "`ivaxdec` DOUBLE NOT NULL " _
        & ") ENGINE=INNODB DEFAULT CHARSET=latin1;"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        ' FORMATO 1007
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".`f1007` (" _
          & "`codcon` VARCHAR(4) NOT NULL, " _
          & "`tdoc` VARCHAR(2) NOT NULL, " _
          & "`num_id` VARCHAR(20) NOT NULL, " _
          & "`dv` VARCHAR(1) NOT NULL, " _
          & "`apell1` VARCHAR(60) NOT NULL, " _
          & "`apell2` VARCHAR(60) NOT NULL, " _
          & "`nom1` VARCHAR(60) NOT NULL, " _
          & "`nom2` VARCHAR(60) NOT NULL, " _
          & "`rsocial` VARCHAR(400) NOT NULL, " _
          & "`dir` VARCHAR(200) NOT NULL, " _
          & "`pais` VARCHAR(4) NOT NULL, " _
          & "`ingprop` DOUBLE NOT NULL, " _
          & "`ingcons` DOUBLE NOT NULL, " _
          & "`ingcont` DOUBLE NOT NULL, " _
          & "`ingmin` DOUBLE NOT NULL," _
          & "`ingfid` DOUBLE NOT NULL, " _
          & "`ingter` DOUBLE NOT NULL, " _
          & "`devdes` DOUBLE NOT NULL " _
        & ") ENGINE=INNODB DEFAULT CHARSET=latin1;"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try


        Try  ' FORMATO 1008
            myCommand.Parameters.Clear()
            myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".`f1008` (" _
          & "`codcon` VARCHAR(4) NOT NULL, " _
          & "`tdoc` VARCHAR(2) NOT NULL, " _
          & "`num_id` VARCHAR(20) NOT NULL, " _
          & "`dv` VARCHAR(1) NOT NULL, " _
          & "`apell1` VARCHAR(60) NOT NULL, " _
          & "`apell2` VARCHAR(60) NOT NULL, " _
          & "`nom1` VARCHAR(60) NOT NULL, " _
          & "`nom2` VARCHAR(60) NOT NULL, " _
          & "`rsocial` VARCHAR(400) NOT NULL, " _
          & "`dir` VARCHAR(200) NOT NULL, " _
          & "`dpto` VARCHAR(2) NOT NULL, " _
          & "`mcp` VARCHAR(5) NOT NULL, " _
          & "`pais` VARCHAR(4) NOT NULL, " _
          & "`salcxc` DOUBLE NOT NULL " _
        & ") ENGINE=INNODB DEFAULT CHARSET=latin1;"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Try ' FORMATO 1009
            myCommand.Parameters.Clear()
            myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".`f1008` (" _
         & "`codcon` VARCHAR(4) NOT NULL, " _
         & "`tdoc` VARCHAR(2) NOT NULL, " _
         & "`num_id` VARCHAR(20) NOT NULL, " _
         & "`dv` VARCHAR(1) NOT NULL, " _
         & "`apell1` VARCHAR(60) NOT NULL, " _
         & "`apell2` VARCHAR(60) NOT NULL, " _
         & "`nom1` VARCHAR(60) NOT NULL, " _
         & "`nom2` VARCHAR(60) NOT NULL, " _
         & "`rsocial` VARCHAR(400) NOT NULL, " _
         & "`dir` VARCHAR(200) NOT NULL, " _
         & "`dpto` VARCHAR(2) NOT NULL, " _
         & "`mcp` VARCHAR(5) NOT NULL, " _
         & "`pais` VARCHAR(4) NOT NULL, " _
         & "`salcxp` DOUBLE NOT NULL " _
       & ") ENGINE=INNODB DEFAULT CHARSET=latin1;"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Try ' FORMATO 1010
            myCommand.Parameters.Clear()
            myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".`f1010` (" _
              & "`codcon` VARCHAR(4) NOT NULL, " _
              & "`tdoc` VARCHAR(2) NOT NULL, " _
              & "`num_id` VARCHAR(20) NOT NULL, " _
              & "`dv` CHAR(1) NOT NULL, " _
              & "`apell1` VARCHAR(100) NOT NULL, " _
              & "`apell2` VARCHAR(100) NOT NULL, " _
              & "`nom1` VARCHAR(100) NOT NULL, " _
              & "`nom2` VARCHAR(100) NOT NULL, " _
              & "`rsocial` VARCHAR(400) NOT NULL, " _
              & "`dir` VARCHAR(200) NOT NULL, " _
              & "`dpto` VARCHAR(2) NOT NULL, " _
              & "`mcp` VARCHAR(5) NOT NULL, " _
              & "`pais` VARCHAR(4) NOT NULL, " _
              & "`vaporte` DOUBLE NOT NULL, " _
              & "`ppart` DOUBLE NOT NULL, " _
              & "`ppartd` DOUBLE NOT NULL " _
              & ") ENGINE=INNODB DEFAULT CHARSET=latin1;"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Try ' FORMATO 1011
            myCommand.Parameters.Clear()
            myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".`f1011` (" _
           & "`codcon` VARCHAR(4) NOT NULL, " _
           & "`saldo` DOUBLE NOT NULL " _
           & ") ENGINE=INNODB DEFAULT CHARSET=latin1;"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Try ' FORMATO 1012
            myCommand.Parameters.Clear()
            myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".`f1012` (" _
         & "`codcon` VARCHAR(4) NOT NULL, " _
         & "`tdoc` VARCHAR(2) NOT NULL, " _
         & "`num_id` VARCHAR(20) NOT NULL, " _
         & "`dv` VARCHAR(1) NOT NULL, " _
         & "`apell1` VARCHAR(60) NOT NULL, " _
         & "`apell2` VARCHAR(60) NOT NULL, " _
         & "`nom1` VARCHAR(60) NOT NULL, " _
         & "`nom2` VARCHAR(60) NOT NULL, " _
         & "`rsocial` VARCHAR(400) NOT NULL, " _
         & "`dir` VARCHAR(200) NOT NULL, " _
         & "`dpto` VARCHAR(2) NOT NULL, " _
         & "`mcp` VARCHAR(5) NOT NULL, " _
         & "`pais` VARCHAR(4) NOT NULL, " _
         & "`valor` DOUBLE NOT NULL " _
       & ") ENGINE=INNODB DEFAULT CHARSET=latin1;"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try


    End Sub

    Public Sub CreateImpuestos(ByVal bd As String)
        Try
            'TABLA CONCEPTOS GRLES DE IMPUESTOS
            myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".con_gral_imp (" _
                                  & "`cod_concep` VARCHAR( 4 ) NOT NULL COMMENT 'codigo del concepto gral'," _
                                  & "`decrip_gral` VARCHAR( 50 ) NOT NULL ,PRIMARY KEY ( `cod_concep` ));"
            myCommand.ExecuteNonQuery()
            'TABLA IMPUESTOS
            myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".impuestos (" _
                                  & "`id_imp` int(11) NOT NULL,`cod_concep` VARCHAR( 4 ) NOT NULL ,`codigo` VARCHAR( 4 ) NOT NULL ," _
                                  & "`descrip` TEXT NOT NULL ,`porce` DECIMAL( 10, 2 ) NOT NULL ,`cuenta` VARCHAR( 10 ) NOT NULL ," _
                                  & "`tip_asi` CHAR( 1 ) NOT NULL,  PRIMARY KEY  (`id_imp`) );"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub
    '******************************************************

    Public Sub Contabilidad(ByVal bd As String)
        'CREAR TABLA SELPUC (CUENTAS QUE UTILIZA LA COMPAÑIA)
        myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".selpuc (" _
                               & " `codigo` varchar(10) NOT NULL DEFAULT '',`descripcion` varchar(100) NOT NULL,`naturaleza` varchar(1) NOT NULL DEFAULT 'D',`nivel` varchar(12) NOT NULL DEFAULT 'Auxiliar'," _
                               & "`tipo` varchar(10) NOT NULL DEFAULT 'Activo',`saldo` double NOT NULL DEFAULT '0',`saldo00` double NOT NULL DEFAULT '0',`debito00` double NOT NULL DEFAULT '0',`credito00` double NOT NULL DEFAULT '0',`debito01` double NOT NULL DEFAULT '0'," _
                               & "`credito01` double NOT NULL DEFAULT '0',`saldo01` double NOT NULL DEFAULT '0',`debito02` double NOT NULL DEFAULT '0',`credito02` double NOT NULL DEFAULT '0'," _
                               & "`saldo02` double NOT NULL DEFAULT '0',`debito03` double NOT NULL DEFAULT '0',`credito03` double NOT NULL DEFAULT '0',`saldo03` double NOT NULL DEFAULT '0'," _
                               & "`debito04` double NOT NULL DEFAULT '0',`credito04` double NOT NULL DEFAULT '0',`saldo04` double NOT NULL DEFAULT '0',`debito05` double NOT NULL DEFAULT '0'," _
                               & "`credito05` double NOT NULL DEFAULT '0',`saldo05` double NOT NULL DEFAULT '0',`debito06` double NOT NULL DEFAULT '0',`credito06` double NOT NULL DEFAULT '0'," _
                               & "`saldo06` double NOT NULL DEFAULT '0',`debito07` double NOT NULL DEFAULT '0',`credito07` double NOT NULL DEFAULT '0',`saldo07` double NOT NULL DEFAULT '0'," _
                               & "`debito08` double NOT NULL DEFAULT '0',`credito08` double NOT NULL DEFAULT '0',`saldo08` double NOT NULL DEFAULT '0',`debito09` double NOT NULL DEFAULT '0'," _
                               & "`credito09` double NOT NULL DEFAULT '0',`saldo09` double NOT NULL DEFAULT '0',`debito10` double NOT NULL DEFAULT '0',`credito10` double NOT NULL DEFAULT '0'," _
                               & "`saldo10` double NOT NULL DEFAULT '0',`debito11` double NOT NULL DEFAULT '0',`credito11` double NOT NULL DEFAULT '0',`saldo11` double NOT NULL DEFAULT '0'," _
                               & "`debito12` double NOT NULL DEFAULT '0',`credito12` double NOT NULL DEFAULT '0',`saldo12` double NOT NULL DEFAULT '0',`tipo_saldo` VARCHAR( 2 ) NOT NULL DEFAULT  'NO', PRIMARY KEY (`codigo`)) ENGINE=MyISAM DEFAULT CHARSET=utf8;"
        myCommand.ExecuteNonQuery()
        'CENTROS DE COSTOS
        myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".`centrocostos` (`centro` varchar(15) NOT NULL, `nombre` varchar(100) NOT NULL,`pres` double NOT NULL,`nivel` varchar(15) NOT NULL , PRIMARY KEY (`centro`));"
        myCommand.ExecuteNonQuery()

        'NIVELES CENTRO DE COSTO
        myCommand.CommandText = "  CREATE TABLE IF NOT EXISTS " & bd & ".`ccnivel` (" _
          & " `numnv` INT NOT NULL , " _
          & " `n1` VARCHAR( 10 ) NOT NULL , " _
          & " `lon1` INT NOT NULL , " _
          & " `n2` VARCHAR( 10 ) NOT NULL , " _
          & " `lon2` INT NOT NULL , " _
          & "`n3` VARCHAR( 10 ) NOT NULL , " _
          & "`lon3` INT NOT NULL , " _
          & "`n4` VARCHAR( 10 ) NOT NULL , " _
          & "`lon4` INT NOT NULL " _
          & ") ENGINE = INNODB; "
        myCommand.ExecuteNonQuery()


        'RETE CREE
        myCommand.CommandText = " CREATE TABLE IF NOT EXISTS " & bd & ".`retecree` (" _
          & " `codigo` varchar(100) NOT NULL, " _
          & " `actividad` text NOT NULL, " _
          & " `tarifa` double NOT NULL, " _
          & " `cuenta` varchar(15) NOT NULL," _
          & " PRIMARY KEY  (`codigo`) " _
          & " ) ENGINE=InnoDB DEFAULT CHARSET=latin1;  "
        myCommand.ExecuteNonQuery()
        ' 
        Try
            SelReteCree()
        Catch ex As Exception
        End Try

        'CUENTA CREADAS POR DEFECTO
        Try
            If FrmGestionCompa.cbtipo.Text = "comercial" Then
                SelPUC()
            End If
        Catch ex As Exception
        End Try
        Dim doc As String
        For i = 0 To 12
            'CREAR LAS TABLAS DOCUMENTOS 
            If i <= 9 Then
                doc = bd & ".documentos0" & i
            Else
                doc = bd & ".documentos" & i
            End If
            myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & doc & "(" _
                                  & "`item` int(4) NOT NULL,  `doc` bigint(20) NOT NULL,  `tipodoc` varchar(2) NOT NULL, `periodo` varchar(10) NOT NULL," _
                                  & "`dia` varchar(2) NOT NULL DEFAULT '',`centro` varchar(15) NOT NULL, `descri` varchar(50) NOT NULL,  `debito` double NOT NULL DEFAULT '0'," _
                                  & "`credito` double NOT NULL DEFAULT '0', `codigo` varchar(10) NOT NULL DEFAULT '', `base` double NOT NULL DEFAULT '0'," _
                                  & "`diasv` int(4) NOT NULL DEFAULT '0', `fechaven` varchar(10) NOT NULL DEFAULT '00/00/0000', `nit` varchar(20) NOT NULL DEFAULT '0',`modulo` varchar(15) NOT NULL DEFAULT 'contabilidad'," _
                                  & "FOREIGN KEY (nit) REFERENCES terceros (nit) ON DELETE CASCADE ON UPDATE CASCADE," _
                                  & "FOREIGN KEY (codigo) REFERENCES selpuc (codigo) ON DELETE CASCADE ON UPDATE CASCADE," _
                                  & "FOREIGN KEY (tipodoc) REFERENCES tipdoc (tipodoc) ON DELETE CASCADE ON UPDATE CASCADE" _
                                  & ") ENGINE=MyISAM DEFAULT CHARSET=utf8;"
            myCommand.ExecuteNonQuery()

            Try
                myCommand.CommandText = " ALTER TABLE  " & doc & " ADD  `cheque` VARCHAR( 20 ) NOT NULL AFTER  `nit` ; "
                myCommand.ExecuteNonQuery()
            Catch ex As Exception
            End Try

            'CREAR TABLAS OTROS DOCUMENTOS
            If i > 0 Then
                If i <= 9 Then
                    doc = bd & ".ot_doc0" & i
                Else
                    doc = bd & ".ot_doc" & i
                End If
                myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & doc & " (`item` bigint(20) NOT NULL,`doc` varchar(15) NOT NULL,`grupo` varchar(2) NOT NULL,`tipo` varchar(4) NOT NULL,`num` bigint(20) NOT NULL,`doc_afec` varchar(15) NOT NULL,`dia` varchar(2) NOT NULL, " _
                                      & "`periodo` varchar(8) NOT NULL,`ciudad` varchar(30) NOT NULL,`concepto` text NOT NULL,`nitc` varchar(20) NOT NULL,`tn` varchar(4) NOT NULL,`codigo` varchar(18) NOT NULL,`descrip` varchar(100) NOT NULL,`debito` double NOT NULL, " _
                                      & "`credito` double NOT NULL,`base` double NOT NULL,`total` double NOT NULL,`efectivo` char(1) NOT NULL,`cheque` varchar(20) NOT NULL,`banco` varchar(50) NOT NULL,`sucursal` varchar(50) NOT NULL,`ccosto` varchar(15) NOT NULL,`fecha` date NOT NULL,`elaborado` varchar(50) NOT NULL,`autorizado` varchar(50) NOT NULL,`revisado` varchar(50) NOT NULL,`contabilizado` varchar(50) NOT NULL, " _
                                      & "`doc_aj` varchar(30) NOT NULL );"
                myCommand.ExecuteNonQuery()
            End If

            'CREAR TABLA OBSDOCUMENTOS
            If i > 0 Then
                If i <= 9 Then
                    doc = bd & ".obsdocumentos0" & i
                Else
                    doc = bd & ".obsdocumentos" & i
                End If
                myCommand.CommandText = " CREATE TABLE IF NOT EXISTS " & doc & " (" _
                  & " `doc` bigint(20) NOT NULL, " _
                  & " `tipodoc` varchar(2) NOT NULL, " _
                  & " `comentario` text NOT NULL, " _
                  & " KEY `doc` (`doc`,`tipodoc`) " _
                & " ) ENGINE=InnoDB DEFAULT CHARSET=latin1; "
                myCommand.ExecuteNonQuery()
            End If
        Next
        'PARAMETROS OTROS DOCUMENTOS
        myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".parotdoc (`ce` VARCHAR( 4 ) NOT NULL,`ci` VARCHAR( 4 ) NOT NULL ,`rc` VARCHAR( 4 ) NOT NULL,`nd` VARCHAR( 4 ) NOT NULL ,`nc` VARCHAR( 4 ) NOT NULL ,`cd` VARCHAR( 4 ) NOT NULL ,`aj` VARCHAR( 4 ) NOT NULL, `logo` VARCHAR( 2 ) NOT NULL DEFAULT  'NO');"
        Try
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        'ESTADOS DE LOS PERIODOS (PARA BLOQUEAR PER)
        myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".bloq_per (`periodo` varchar(2) NOT NULL DEFAULT '00',`bloqueado` char(2) NOT NULL DEFAULT 'n', PRIMARY KEY (`periodo`));" _
                              & "INSERT INTO " & bd & ".bloq_per VALUES ('00','n');" _
                              & "INSERT INTO " & bd & ".bloq_per VALUES ('01','n');" _
                              & "INSERT INTO " & bd & ".bloq_per VALUES ('02','n');" _
                              & "INSERT INTO " & bd & ".bloq_per VALUES ('03','n');" _
                              & "INSERT INTO " & bd & ".bloq_per VALUES ('04','n');" _
                              & "INSERT INTO " & bd & ".bloq_per VALUES ('05','n');" _
                              & "INSERT INTO " & bd & ".bloq_per VALUES ('06','n');" _
                              & "INSERT INTO " & bd & ".bloq_per VALUES ('07','n');" _
                              & "INSERT INTO " & bd & ".bloq_per VALUES ('08','n');" _
                              & "INSERT INTO " & bd & ".bloq_per VALUES ('09','n');" _
                              & "INSERT INTO " & bd & ".bloq_per VALUES ('10','n');" _
                              & "INSERT INTO " & bd & ".bloq_per VALUES ('11','n');" _
                              & "INSERT INTO " & bd & ".bloq_per VALUES ('12','n');"
        Try
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        'CREAR TABLA NIVELES DE CUENTAS
        Try
            myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".parcontab (" _
                               & "`longitud` int(10) unsigned NOT NULL,`niveles` int(10) unsigned NOT NULL,`nivel1` int(11) unsigned NOT NULL DEFAULT '0',`nivel2` int(11) unsigned NOT NULL DEFAULT '0'," _
                               & "`nivel3` int(10) unsigned NOT NULL,`nivel4` int(10) unsigned NOT NULL,`nivel5` int(11) unsigned NOT NULL DEFAULT '0',`ccosto` varchar(2) NOT NULL, PRIMARY KEY (`longitud`)) ENGINE=MyISAM DEFAULT CHARSET=utf8;" _
                               & "INSERT INTO " & bd & ".`parcontab` VALUES (9,5,1,1,2,2,3,'N');"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        'CREAR TABLAS CUENTAS DE INFORMES TRIBUTARIOS
        myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".`tributarios` (" _
        & "`num` int(11) NOT NULL,`detalle` varchar(30) NOT NULL,`cuenta1` varchar(15) NOT NULL,`cuenta2` varchar(15) NOT NULL," _
        & "`cuenta3` varchar(15) NOT NULL,`cuenta4` varchar(15) NOT NULL,`cuenta5` varchar(15) NOT NULL " _
        & " ,`cuenta6` varchar(15) NOT NULL, `cuenta7` varchar(15) NOT NULL, `cuenta8` varchar(15) NOT NULL, " _
        & " `cuenta9` varchar(15) NOT NULL, `cuenta10` varchar(15) NOT NULL, `cuenta11` varchar(15) NOT NULL, " _
        & " `cuenta12` varchar(15) NOT NULL, PRIMARY KEY (`num`)) ENGINE=MyISAM DEFAULT CHARSET=utf8;" _
        & "INSERT INTO " & bd & ".`tributarios` VALUES (1, 'I.V.A Recaudado (por pagar)', '', '', '', '', '', '', '', '', '', '', '', ''); " _
        & "INSERT INTO " & bd & ".`tributarios` VALUES (2, 'I.V.A Pagado (descontable)', '', '', '', '', '', '', '', '', '', '', '', ''); " _
        & "INSERT INTO " & bd & ".`tributarios` VALUES (3, 'Retenciones hechas por tercero', '', '', '', '', '', '', '', '', '', '', '', ''); " _
        & "INSERT INTO " & bd & ".`tributarios` VALUES (4, 'Retenciones hechas a terceros', '', '', '', '', '', '', '', '', '', '', '', ''); " _
        & "INSERT INTO " & bd & ".`tributarios` VALUES (5, 'I.V.A Retenidos a terceros', '', '', '', '', '', '', '', '', '', '', '', ''); " _
        & "INSERT INTO " & bd & ".`tributarios` VALUES (6, 'I.C.A Retenidos a terceros', '', '', '', '', '', '', '', '', '', '', '', ''); " _
        & "INSERT INTO " & bd & ".`tributarios` VALUES (7, 'Informes de Otras Cuentas', '', '', '', '', '', '', '', '', '', '', '', ''); " _
        & "INSERT INTO " & bd & ".`tributarios` VALUES (8, 'Retencion CREE', '', '', '', '', '', '', '', '', '', '', '', ''); "
        Try
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

    End Sub
    Public Sub SelPUC()
        Dim nom As String
        Try
            nom = "\puc_bas.txt"
        Catch ex As Exception
            nom = ""
        End Try
        If nom = "" Then Exit Sub
        '**********************************************************
        Dim Archivo As String
        Try
            Dim rutaconex As String
            rutaconex = My.Application.Info.DirectoryPath & nom
            If My.Computer.FileSystem.FileExists(rutaconex) Then
                Archivo = My.Computer.FileSystem.ReadAllText(rutaconex)
                Try
                    myCommand.CommandText = Archivo
                    myCommand.ExecuteNonQuery()
                Catch ex As Exception
                End Try
            Else
                MsgBox("Error #3266 al seleecionar el PUC basico, Verifique con el Administrador", MsgBoxStyle.Critical, "Verificando")
            End If
        Catch ex As Exception
            MsgBox("Error #3266 " & ex.Message.ToString, MsgBoxStyle.Critical)
            End
        End Try
    End Sub
    Public Sub SelReteCree()
        Dim nom As String
        Try
            nom = "\retecree.txt"
        Catch ex As Exception
            nom = ""
        End Try
        If nom = "" Then Exit Sub
        '**********************************************************
        Dim Archivo As String
        Try
            Dim rutaconex As String
            rutaconex = My.Application.Info.DirectoryPath & nom
            If My.Computer.FileSystem.FileExists(rutaconex) Then
                Archivo = My.Computer.FileSystem.ReadAllText(rutaconex)
                Try
                    myCommand.CommandText = Archivo
                    myCommand.ExecuteNonQuery()
                Catch ex As Exception
                End Try
            Else
                MsgBox("Error al ingresar las actividades economicas, Verifique con el Administrador", MsgBoxStyle.Critical, "Verificando")
            End If
        Catch ex As Exception
            MsgBox("Error #3266 " & ex.Message.ToString, MsgBoxStyle.Critical)
            End
        End Try
    End Sub
    'INSERT SEL PUC
    Public Sub InsertPUC(ByVal sql As String)
        Try
            myCommand.CommandText = sql
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            'MsgBox(sql & "  --- " & ex.ToString)
        End Try
    End Sub
    'FACTURACIÓN
    Public Sub Facturacion(ByVal bd As String)
        ''************* TABLA SERVICIOS
        myCommand.CommandText = "CREATE TABLE " & bd & ".`servicios` (`codser` varchar(15) NOT NULL,`nombre` varchar(80) NOT NULL, `descrip` text NOT NULL,`pventa` double NOT NULL,`pventa2` double NOT NULL default '0',`pventa3` double NOT NULL default '0',`pventa4` double NOT NULL default '0',`pventa5` double NOT NULL default '0',`pventa6` double NOT NULL default '0',`iva` DECIMAL( 10, 2 ) NOT NULL,`cta_ing` varchar(15) NOT NULL," _
        & "`cta_iva` varchar(15) NOT NULL,PRIMARY KEY (`codser`)) ENGINE=MyISAM DEFAULT CHARSET=utf8;"
        myCommand.ExecuteNonQuery()
        ''************* TABLA PARAMETROS FACTURA GENERAL
        myCommand.CommandText = "CREATE TABLE " & bd & ".parafacgral (" _
        & "`tipof1` varchar(4) NOT NULL,`tipof2` varchar(4) NOT NULL,`tipof3` varchar(4) NOT NULL,`tipof4` varchar(4) NOT NULL, `tipoaj` varchar(4) NOT NULL,`a_f1` bigint(20) NOT NULL, `a_f2` bigint(20) NOT NULL, `a_f3` bigint(20) NOT NULL, `a_f4` bigint(20) NOT NULL, `hr1` varchar(2) NOT NULL,`hr2` varchar(2) NOT NULL,`hr3` varchar(2) NOT NULL,`hr4` varchar(2) NOT NULL," _
        & "`reso1` varchar(30) NOT NULL,`reso2` varchar(30) NOT NULL,`reso3` varchar(30) NOT NULL,`reso4` varchar(30) NOT NULL,`fecexp1` date NOT NULL,`fecexp2` date NOT NULL,`fecexp3` date NOT NULL,`fecexp4` date NOT NULL,`feclim1` date NOT NULL,`feclim2` date NOT NULL,`feclim3` date NOT NULL,`feclim4` date NOT NULL," _
        & "`ini1` bigint(20) NOT NULL,`ini2` bigint(20) NOT NULL,`ini3` bigint(20) NOT NULL,`ini4` bigint(20) NOT NULL,`fin1` bigint(20) NOT NULL,`fin2` bigint(20) NOT NULL,`fin3` bigint(20) NOT NULL,`fin4` bigint(20) NOT NULL,`formcosto` varchar(20) NOT NULL,`ivainclu` varchar(2) NOT NULL, `comventa` varchar(2) NOT NULL," _
        & "`intecontab` varchar(2) NOT NULL,`caja` varchar(15) DEFAULT NULL, `bancos` varchar(15) DEFAULT NULL,`ctapc` varchar(15) DEFAULT NULL,`inventario` varchar(15) DEFAULT NULL,`ventas` varchar(15) DEFAULT NULL,`costoventa` varchar(15) DEFAULT NULL," _
        & "`ivapp` varchar(15) DEFAULT NULL,`ivadesc` varchar(15) DEFAULT NULL,`porivapp` decimal(10,2) DEFAULT NULL,`porivadesc` decimal(10,2) DEFAULT NULL,`descuento` varchar(15) DEFAULT NULL,`retfuente` varchar(15) DEFAULT NULL,`reteica` varchar(15) DEFAULT NULL,`reteiva` varchar(15) DEFAULT NULL, " _
        & "`pre1` VARCHAR( 10 ) NOT NULL ,`pre2` VARCHAR( 10 ) NOT NULL ,`pre3` VARCHAR( 10 ) NOT NULL ,`pre4` VARCHAR( 10 ) NOT NULL ,`lista_art` VARCHAR( 10 ) NOT NULL DEFAULT 'SI',`lista_pre` VARCHAR( 3 ) NOT NULL DEFAULT 'SI',`Guar_Ap` VARCHAR( 2 ) NOT NULL DEFAULT 'N') ENGINE=MyISAM DEFAULT CHARSET=utf8;"
        myCommand.ExecuteNonQuery()
        ActualizarPrefijo(bd)
        ''********** TABLA PARAMETROS FACTURA RAPIDA Y NORMAL
        myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".parafacts (" _
        & "`factura` varchar(10) NOT NULL,`doc` char(1) NOT NULL,`tipodoc` varchar(4) NOT NULL,`numfact` varchar(15) NOT NULL,`afecinv` char(1) NOT NULL,`fecha` varchar(15) NOT NULL,`nitcpre` char(1) NOT NULL,`nitc` varchar(15) NOT NULL,`nitvpre` char(1) NOT NULL,`nitv` varchar(15) NOT NULL,`codinv` char(1) NOT NULL,`centrocost` char(1) NOT NULL," _
        & "`facdifuniemp` char(1) NOT NULL,`precautcant` char(1) NOT NULL,`bodpred` char(1) NOT NULL,`idbod` varchar(15) NOT NULL,`margmin` char(1) NOT NULL,`margen` varchar(15) NOT NULL,`concomipre` char(1) NOT NULL,`concomi` varchar(10) NOT NULL,`fpagopre` char(1) NOT NULL,`cualfp` varchar(15) NOT NULL,`formatfac` varchar(10) NOT NULL,`logofac` longblob," _
        & "`formatped` varchar(10) NOT NULL,`logoped` longblob, `formatcot` varchar(10) NOT NULL, `logocot` longblob,`tipocompa` varchar(30) NOT NULL,`comentario` text NOT NULL,`imp_dec` char(1) NOT NULL default 'S', bus_cli VARCHAR( 3 ) NOT NULL DEFAULT  'N', `GuarNumFac` VARCHAR( 2 ) NOT NULL DEFAULT 'N', `comentario_ini` TEXT NOT NULL ," _
        & "PRIMARY KEY (`factura`)," _
        & "FOREIGN KEY (nitc) REFERENCES terceros (nit) ON DELETE CASCADE ON UPDATE CASCADE," _
        & "FOREIGN KEY (nitv) REFERENCES vendedores (nitv) ON DELETE CASCADE ON UPDATE CASCADE" _
        & ") ENGINE=MyISAM DEFAULT CHARSET=utf8;"
        myCommand.ExecuteNonQuery()
        ''************** TABLA VENDEDORES
        myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".`vendedores` (`nitv` varchar(15) NOT NULL,`nombre` varchar(70) NOT NULL,`dir` varchar(50) NOT NULL, `telefono` varchar(15) NOT NULL," _
        & "`estado` varchar(10) NOT NULL,`zona` varchar(20) NOT NULL,`palm` varchar(2) NOT NULL,`codpalm` varchar(20) NOT NULL, PRIMARY KEY (`nitv`)) ENGINE=MyISAM DEFAULT CHARSET=utf8;"
        myCommand.ExecuteNonQuery()
       
        ''************** TABLA VENDEDORES POR CONCEPTO COMICIONABLE
        myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".`vend_cc` (`nitv` VARCHAR( 15 ) NOT NULL ,`codcon` INT NOT NULL ,`porcomi` DECIMAL( 10, 2 ) NOT NULL ,`dia_cob` INT NOT NULL);"
        myCommand.ExecuteNonQuery()
        '**************** LISTA PRECIO X CLIENTES ******
        myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".`lista_cliente` (" _
        & "`numlist` INT NOT NULL ,`nitc` VARCHAR( 20 ) NOT NULL ,UNIQUE (`nitc`));"
        myCommand.ExecuteNonQuery()
        Dim per As String
        For i = 1 To 12
            If i < 10 Then
                per = "0" & i
            Else
                per = i
            End If
            ''*************** TABLA FACTURAS ****************************************
            myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".`facturas" & per & "` (`doc` varchar(15) NOT NULL,`num` bigint(10) NOT NULL,`tipodoc` varchar(4) NOT NULL,`doc_de` char(1) NOT NULL,`nitc` varchar(15) NOT NULL,`nitv` varchar(15) NOT NULL,`usuario` varchar(15) NOT NULL,`fecha` date NOT NULL," _
            & "`hora` time NOT NULL,`descrip` text NOT NULL,`doc_afec` varchar(15) NOT NULL,`afecta` varchar(2) NOT NULL,`subtotal` double NOT NULL,`por_desc` decimal(10,2) NOT NULL,`descuento` double NOT NULL,`cta_desc` varchar(15) NOT NULL,`por_ret_f` decimal(10,2) NOT NULL,`ret_f` double NOT NULL," _
            & "`cta_ret_f` varchar(15) NOT NULL,`por_iva` decimal(10,2) NOT NULL,`iva` double NOT NULL,`cta_iva` varchar(15) NOT NULL,`por_ret_iva` decimal(10,2) NOT NULL,`ret_iva` double NOT NULL,`cta_ret_iva` varchar(15) NOT NULL,`por_ret_ica` decimal(10,2) NOT NULL,`ret_ica` double NOT NULL,`cta_ret_ica` varchar(15) NOT NULL," _
            & "`total` double NOT NULL,`cta_total` varchar(15) NOT NULL,`estado` varchar(2) NOT NULL,`observ` text NOT NULL,`vmto` int(11) NOT NULL,`entregar` TEXT NOT NULL,`dir_ent` varchar(50) NOT NULL,`ciu_ent` varchar(30) NOT NULL,`o_compra` varchar(15) NOT NULL,`fecha_o` varchar(15) NOT NULL,`cc` varchar(15) NOT NULL, " _
            & " `o_con` varchar(2) NOT NULL default 'no'," _
          & " `t1` char(1) NOT NULL, " _
          & " `d1` varchar(100) NOT NULL," _
          & " `v1` double NOT NULL, " _
          & " `cta1` varchar(15) NOT NULL," _
          & " `t2` char(1) NOT NULL," _
          & " `d2` varchar(100) NOT NULL," _
          & " `v2` double NOT NULL," _
          & " `cta2` varchar(15) NOT NULL," _
          & " `t3` char(1) NOT NULL," _
          & " `d3` varchar(100) NOT NULL," _
          & " `v3` double NOT NULL," _
          & " `cta3` varchar(15) NOT NULL," _
          & " `doc1` varchar(25) NOT NULL default ' '," _
          & " `doc2` varchar(25) NOT NULL default ' '," _
          & " `doc3` varchar(25) NOT NULL default ' '," _
          & " `valor_aj` DOUBLE NOT NULL COMMENT  'valor ajuste'," _
          & " `por_rtc` DECIMAL( 10, 2 ) NOT NULL ," _
          & " `rtc` DOUBLE NOT NULL , " _
          & " `cta_rtc` VARCHAR( 15 ) NOT NULL , " _
          & " PRIMARY KEY  (`doc`)," _
          & " KEY `nitc` (`nitc`)," _
          & " KEY `nitv` (`nitv`)," _
          & " KEY `tipodoc` (`tipodoc`)" _
          & " ) ENGINE=MyISAM DEFAULT CHARSET=utf8;"
            myCommand.ExecuteNonQuery()
            ''**************** TABLA DETALLES FACTURAS *********************************
            myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".`detafac" & per & "` (`doc` varchar(15) NOT NULL,`item` int(11) NOT NULL,`tipo_it` char(1) NOT NULL, `codart` varchar(18) NOT NULL, `nomart` TEXT NOT NULL,`numbod` int(11) NOT NULL,`cantidad` double NOT NULL," _
            & "`valor` double NOT NULL,`vtotal` double NOT NULL,`iva_d` DECIMAL( 10, 2 ) NOT NULL,`por_des` DECIMAL( 10, 2 ) NOT NULL DEFAULT '0.00', `cta_inv` varchar(15) NOT NULL,`cta_cos` varchar(15) NOT NULL,`cta_ing` varchar(15) NOT NULL,`cta_iva` varchar(15) NOT NULL,`costo` double NOT NULL,`concep` varchar(10) NOT NULL,`nit` VARCHAR( 15 ) NOT NULL ," _
            & "FOREIGN KEY (doc) REFERENCES facturas" & per & " (doc) ON DELETE CASCADE ON UPDATE CASCADE" _
            & ") ENGINE=MyISAM DEFAULT CHARSET=utf8;"
            myCommand.ExecuteNonQuery()
            ''*************** TABLA FORMAS DE PAGOS ************************************
            myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".`facpagos" & per & "` (`doc` varchar(15) NOT NULL,`tipo` varchar(15) NOT NULL,`descrip` varchar(60) NOT NULL,`tt` varchar(2) NOT NULL,`banco` varchar(30) NOT NULL,`numero` varchar(30) NOT NULL,`valor` double NOT NULL," _
            & "FOREIGN KEY (doc) REFERENCES facturas" & per & " (doc) ON DELETE CASCADE ON UPDATE CASCADE" _
            & ") ENGINE=MyISAM DEFAULT CHARSET=utf8;"
            myCommand.ExecuteNonQuery()
            ''********** OTROS CONCEPTOS FAC
            myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".`otcon_fac" & per & "` (" _
                 & "`doc` varchar(15) NOT NULL, " _
                 & "`item` int(11) NOT NULL, " _
                 & "`tipo` char(1) NOT NULL, " _
                 & "`descrip` varchar(100) NOT NULL, " _
                 & "`valor` double NOT NULL, " _
                 & "`cta` varchar(15) NOT NULL, " _
                 & "`base` double NOT NULL default '0', " _
                 & "`doc_ant` varchar(25) NOT NULL default ' '," _
                 & "KEY `doc` (`doc`) " _
               & ") ENGINE=InnoDB DEFAULT CHARSET=latin1; "
            myCommand.ExecuteNonQuery()
        Next
        ''*************** TABLA DEVOLUCIONES
        'myCommand.CommandText = ""
        'myCommand.ExecuteNonQuery()
        '*************** TABLA COTIZACIONES *************************
        myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".`fapipen` (" _
        & "`numero` VARCHAR( 15 ) NOT NULL ,`item` BIGINT NOT NULL ,`tipo` CHAR( 1 ) NOT NULL ,`codart` varchar(18) NOT NULL,`descrip` VARCHAR( 100 ) NOT NULL ,`cantped` DOUBLE NOT NULL ,`cantdes` DOUBLE NOT NULL ,`precio` DOUBLE NOT NULL ,`descto` DOUBLE NOT NULL ,`iva` DECIMAL( 10, 2 ) NOT NULL ,`vtotal` DOUBLE NOT NULL ," _
        & "`concomi` INT NOT NULL ,`factur` CHAR( 1 ) NOT NULL ,`preciva` DOUBLE NOT NULL ,`nitc` VARCHAR( 15 ) NOT NULL ,`nitv` varchar(15) NOT NULL,`empaque` VARCHAR( 15 ) NOT NULL ,`uniemp` DOUBLE NOT NULL ,`costo` DOUBLE NOT NULL ,`lispre` INT NOT NULL ,`ccosto` varchar(15) NOT NULL ,`fecha` date NOT NULL, `observ` text NOT NULL);"
        myCommand.ExecuteNonQuery()
        '*************** TABLA ACTAS DE ENTREGA *************************
        myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".`fact_acta_entrega` (" _
        & "`numero` VARCHAR( 15 ) NOT NULL ,`item` BIGINT NOT NULL ,`tipo` CHAR( 1 ) NOT NULL ,`codart` varchar(18) NOT NULL,`descrip` VARCHAR( 100 ) NOT NULL ,`cantped` DOUBLE NOT NULL ,`cantdes` DOUBLE NOT NULL ,`precio` DOUBLE NOT NULL ,`descto` DOUBLE NOT NULL ,`iva` DECIMAL( 10, 2 ) NOT NULL ,`vtotal` DOUBLE NOT NULL ," _
        & "`concomi` INT NOT NULL ,`factur` CHAR( 1 ) NOT NULL ,`preciva` DOUBLE NOT NULL ,`nitc` VARCHAR( 15 ) NOT NULL ,`nitv` varchar(15) NOT NULL,`empaque` VARCHAR( 15 ) NOT NULL ,`uniemp` DOUBLE NOT NULL ,`costo` DOUBLE NOT NULL ,`lispre` INT NOT NULL ,`ccosto` varchar(15) NOT NULL ,`fecha` date NOT NULL, `observ` text NOT NULL);"
        myCommand.ExecuteNonQuery()
        '******************* OTROS CONCEPTOS FAC
       
    End Sub
    Public Sub ActualizarPrefijo(ByVal bd As String)
        Try
            myCommand.CommandText = "ALTER TABLE " & bd & ".parafacgral ADD `pre1` VARCHAR( 10 ) NOT NULL , ADD `pre2` VARCHAR( 10 ) NOT NULL ,ADD `pre3` VARCHAR( 10 ) NOT NULL ,ADD `pre4` VARCHAR( 10 ) NOT NULL ;"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try

    End Sub
    Public Sub LLenarFacturacion(ByVal nbd As String)
        Dim Sql As String
        'LLENAR TABLA  lista cliente
        Sql = "TRUNCATE TABLE " & nbd & ".lista_cliente; INSERT INTO " & nbd & ".lista_cliente SELECT * FROM " & bda & ".lista_cliente;"
        Insertar(Sql)
        'LLENAR TABLA  listas de precios
        Sql = "TRUNCATE TABLE " & nbd & ".listasprec; INSERT INTO " & nbd & ".listasprec SELECT * FROM " & bda & ".listasprec;"
        Insertar(Sql)
        'LLENAR TABLA  servicios
        Sql = "TRUNCATE TABLE " & nbd & ".servicios; INSERT INTO " & nbd & ".servicios SELECT * FROM " & bda & ".servicios;"
        Insertar(Sql)
        'LLENAR TABLA  vendedores
        Sql = "TRUNCATE TABLE " & nbd & ".vendedores; INSERT INTO " & nbd & ".vendedores SELECT * FROM " & bda & ".vendedores;"
        Insertar(Sql)
        'LLENAR TABLA concomi
        Sql = "TRUNCATE TABLE " & nbd & ".concomi; INSERT INTO " & nbd & ".concomi SELECT * FROM " & bda & ".concomi;"
        Insertar(Sql)
        'LLENAR TABLA vendedores conceptos
        Sql = "TRUNCATE TABLE " & nbd & ".vend_cc; INSERT INTO " & nbd & ".vend_cc SELECT * FROM " & bda & ".vend_cc;"
        Insertar(Sql)
        'LLENAR TABLA parametros generales
        Sql = "TRUNCATE TABLE " & nbd & ".parafacgral; INSERT INTO " & nbd & ".parafacgral SELECT * FROM " & bda & ".parafacgral;"
        Insertar(Sql)
        'LLENAR TABLA parametros facturas
        Sql = "TRUNCATE TABLE " & nbd & ".parafacts; INSERT INTO " & nbd & ".parafacts SELECT * FROM " & bda & ".parafacts;"
        InsertPUC(Sql)
    End Sub
    'inventario
    Public Sub Inventario(ByVal bd As String)
        'CREAR TABLA PARAMETROS INVENTARIOS
        Try
            myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".`parinven` (`longitud` int(11) NOT NULL,`nivel1` int(11) NOT NULL,`desc1` varchar(20) NOT NULL,`nivel2` int(11) NOT NULL,`desc2` varchar(20) NOT NULL," _
           & "`nivel3` int(11) NOT NULL,`desc3` varchar(20) NOT NULL,`nivel4` int(11) NOT NULL,`desc4` varchar(20) NOT NULL, `nivel5` int(11) NOT NULL,`desc5` varchar(20) NOT NULL,`nivel6` int(11) NOT NULL,`desc6` varchar(20) NOT NULL," _
           & "`formula` varchar(30) NOT NULL,`porcen` int(11) NOT NULL,`traslados` varchar(4) NOT NULL,`ajustes` varchar(4) NOT NULL,`entradas` varchar(4) NOT NULL,`salidas` varchar(4) NOT NULL,`codbar` varchar(2) NOT NULL,`contable` varchar(2) NOT NULL," _
           & "`cuenta1` varchar(15) NOT NULL, `cuenta2` varchar(15) NOT NULL,`cuenta3` varchar(15) NOT NULL,`cuenta4` varchar(15) NOT NULL,`cuenta5` varchar(15) NOT NULL,`cuenta6` varchar(15) NOT NULL,`vsalida` VARCHAR( 2 ) NOT NULL DEFAULT  'CS',`cdebito` VARCHAR( 15 ) NOT NULL , `ccredito` VARCHAR( 15 ) NOT NULL,`guar_Ap` VARCHAR( 2 ) NOT NULL DEFAULT  'NO') ENGINE=MyISAM DEFAULT CHARSET=utf8;"
            myCommand.ExecuteNonQuery()
            'CREAR TABLA ARTICULOS
            myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".`articulos` (`codart` varchar(18) NOT NULL,`nomart` varchar(60) NOT NULL,`desart` text NOT NULL,`nivel` varchar(15) NOT NULL,`referencia` varchar(18) NOT NULL,`codbar` varchar(20) NOT NULL,`cos_uni` double NOT NULL," _
            & "`cos_pro` double NOT NULL,`margen` DECIMAL(10,2) NOT NULL,`precio` double NOT NULL,`iva` decimal(10,2) NOT NULL,`exento` varchar(2) NOT NULL,`excluido` varchar(2) NOT NULL,`cue_inv` varchar(15) NOT NULL,`cue_ing` varchar(15) NOT NULL,`cue_cos` varchar(15) NOT NULL,`cue_iva_v` varchar(15) NOT NULL," _
            & "`cue_iva_c` varchar(15) NOT NULL,`cue_dev` varchar(15) NOT NULL,`unidad` varchar(10) NOT NULL,`empaque` double NOT NULL,`can_emp` double NOT NULL,`uni_emp` double NOT NULL,`cant_min` double NOT NULL,`pp` double NOT NULL,`estado` varchar(10) NOT NULL,`con_comi` varchar(20) NOT NULL," _
            & "`importa` varchar(2) NOT NULL,`num_reg` varchar(20) NOT NULL,`por_ara` decimal(10,2) NOT NULL,`pos_ara` varchar(20) NOT NULL,`p1` varchar(15) NOT NULL,`p2` varchar(15) NOT NULL,`p3` varchar(15) NOT NULL,`p4` varchar(15) NOT NULL,`p5` varchar(15) NOT NULL, PRIMARY KEY (`codart`)) ENGINE=MyISAM DEFAULT CHARSET=utf8;"
            myCommand.ExecuteNonQuery()
            'CREAR TABLA BODEGAS
            myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".`bodegas` (`numbod` int(11) NOT NULL AUTO_INCREMENT,`nombod` varchar(70) NOT NULL,PRIMARY KEY (`numbod`)) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;"
            myCommand.ExecuteNonQuery()
            myCommand.CommandText = " INSERT INTO  " & bd & ".`bodegas` ( `nombod` ) VALUES ('GENERAL');"
            myCommand.ExecuteNonQuery()
            'CREAR TABLA LISTAS DE PRECIOS
            myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".`listasprec` (`numlist` int(11) NOT NULL AUTO_INCREMENT,`nomlist` varchar(70) NOT NULL, PRIMARY KEY (`numlist`));"
            myCommand.ExecuteNonQuery()
            myCommand.CommandText = " INSERT INTO  " & bd & ".`listasprec` ( `nomlist` ) VALUES ( 'GENERAL'); "
            myCommand.ExecuteNonQuery()

            'CONSOLIDADOS INVENTARIOS
            myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".`con_inv` (`codart` varchar(18) NOT NULL,`periodo` varchar(2) NOT NULL,`costuni` double NOT NULL default '0',`costprom` double NOT NULL default '0',`costmoe` double NOT NULL default '0',`otro` double NOT NULL default '0'," _
            & "`margen` decimal(10,2) NOT NULL default '0.00',`base` double NOT NULL default '0',`precio1` double NOT NULL default '0',`precio2` double NOT NULL default '0',`precio3` double NOT NULL default '0',`precio4` double NOT NULL default '0',`precio5` double NOT NULL default '0',`precio6` double NOT NULL default '0'," _
            & "`cue_inv` varchar(18) NOT NULL,`cue_cos` varchar(18) NOT NULL,`cue_ing` varchar(18) NOT NULL,`cue_iva_v` varchar(18) NOT NULL,`cue_iva_c` varchar(18) NOT NULL,`cue_dev` varchar(18) NOT NULL,`saldoi` double NOT NULL,`vent` double NOT NULL,`vsal` double NOT NULL,`vaju` double NOT NULL," _
            & "`cant1` double NOT NULL default '0',`cant2` double NOT NULL default '0',`cant3` double NOT NULL default '0',`cant4` double NOT NULL default '0',`cant5` double NOT NULL default '0',`cant6` double NOT NULL default '0',`cant7` double NOT NULL default '0',`cant8` double NOT NULL default '0',`cant9` double NOT NULL default '0',`cant10` double NOT NULL default '0'," _
            & "`cant11` double NOT NULL default '0',`cant12` double NOT NULL default '0',`cant13` double NOT NULL default '0',`cant14` double NOT NULL default '0',`cant15` double NOT NULL default '0',`cant16` double NOT NULL default '0',`cant17` double NOT NULL default '0',`cant18` double NOT NULL default '0',`cant19` double NOT NULL default '0',`cant20` double NOT NULL default '0'," _
            & "`cant21` double NOT NULL default '0',`cant22` double NOT NULL default '0',`cant23` double NOT NULL default '0',`cant24` double NOT NULL default '0',`cant25` double NOT NULL default '0',`cant26` double NOT NULL default '0',`cant27` double NOT NULL default '0',`cant28` double NOT NULL default '0',`cant29` double NOT NULL default '0',`cant30` double NOT NULL default '0'" _
            & ");"
            myCommand.ExecuteNonQuery()
            'MOVIMIENTOS DEL INVENTARIOS
            Dim per As String = ""
            For i = 0 To 12
                If i < 10 Then
                    per = "0" & i
                Else
                    per = i
                End If
                myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".`movimientos" & per & "` (`doc` varchar(15) NOT NULL,`tipodoc` varchar(4) NOT NULL,`num` bigint(20) NOT NULL,`per` varchar(7) NOT NULL," _
                & "`dia` varchar(2) NOT NULL,`hora` time NOT NULL, `nitc` varchar(15) NOT NULL,`tipo_mov` char(1) NOT NULL,`tipo` VARCHAR( 50 ) NOT NULL,`desc_mov` varchar(100) NOT NULL,`cc` varchar(15) NOT NULL,`concepto` text NOT NULL," _
                & "`o_compra` varchar(15) NOT NULL,`n_pedido` varchar(15) NOT NULL,`observ` text NOT NULL,`total` double NOT NULL,`estado` varchar(2) NOT NULL, PRIMARY KEY (`doc`)," _
                & "FOREIGN KEY (nitc) REFERENCES terceros (nit) ON DELETE CASCADE ON UPDATE CASCADE," _
                & "FOREIGN KEY (tipodoc) REFERENCES tipdoc (tipodoc) ON DELETE CASCADE ON UPDATE CASCADE" _
                & ") ENGINE=MyISAM DEFAULT CHARSET=utf8;"
                myCommand.ExecuteNonQuery()
                myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".`deta_mov" & per & "` (`doc` varchar(15) NOT NULL,`item` int(11) NOT NULL,`codart` varchar(18) NOT NULL,`nomart` TEXT NOT NULL,`bod_ori` int(11) NOT NULL,`bod_des` int(11) NOT NULL," _
                & "`cantidad` double NOT NULL,`valor` double NOT NULL,`cta_inv` varchar(15) NOT NULL,`cta_cos` varchar(15) NOT NULL,`cta_ing` varchar(15) NOT NULL,`cta_iva` varchar(15) NOT NULL,costo double NOT NULL," _
                & "FOREIGN KEY (doc) REFERENCES movimientos" & per & " (doc) ON DELETE CASCADE ON UPDATE CASCADE," _
                & "FOREIGN KEY (codart) REFERENCES articulos (codart) ON DELETE CASCADE ON UPDATE CASCADE" _
                & ") ENGINE=MyISAM DEFAULT CHARSET=utf8;"
                myCommand.ExecuteNonQuery()
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub Inmobiliaria(ByVal bd As String)

        'Try

        ' Inmuebles
        Try

            myCommand.CommandText = " CREATE TABLE IF NOT EXISTS " & bd & ".inmuebles (" _
              & " codigo varchar(30) NOT NULL," _
              & " nitp varchar(15) NOT NULL, " _
              & " avaluo double NOT NULL, " _
              & " estado varchar(20) NOT NULL, " _
              & " direccion varchar(100) NOT NULL, " _
              & " ciudad varchar(30) NOT NULL, " _
              & " vcanon double NOT NULL, " _
              & " descrip text NOT NULL, " _
              & " tipoim varchar(20) NOT NULL, " _
              & " operacion varchar(10) NOT NULL, " _
              & " dpto varchar(10) NOT NULL, " _
              & " barrio varchar(100) NOT NULL, " _
              & " estrato varchar(2) NOT NULL, " _
              & " conserv varchar(20) NOT NULL, " _
              & " tipoestado varchar(8) NOT NULL, " _
              & " destino varchar(10) NOT NULL, " _
              & " llaves bigint(20) NOT NULL, " _
              & " previvi double NOT NULL, " _
              & " prelocal double NOT NULL, " _
              & " ncatast varchar(100) NOT NULL, " _
              & " avcatast double NOT NULL, " _
              & " `notaria` VARCHAR( 100 ) NOT NULL ," _
              & " `n_escritura` VARCHAR( 60 ) NOT NULL , " _
              & " `f_escritura` VARCHAR( 100 ) NOT NULL , " _
              & " `matricula` VARCHAR( 100 ) NOT NULL , " _
              & " `inscripcion` VARCHAR( 100 ) NOT NULL, " _
               & " PRIMARY KEY(codigo) " _
              & " ) ENGINE=MyISAM DEFAULT CHARSET=latin1;"
            myCommand.ExecuteNonQuery()

        Catch ex As Exception
        End Try

        Try

            ' terceros inm
            myCommand.CommandText = "  CREATE TABLE  IF NOT EXISTS " & bd & ".`tercerosInm` ( " _
                & "  `num` INT NOT NULL AUTO_INCREMENT PRIMARY KEY , " _
                & " `nit` VARCHAR( 20 ) NOT NULL , " _
                & " `clase` VARCHAR( 20 ) NOT NULL " _
                & " ) ENGINE = MYISAM ; "
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        ' CONTRATOS
        Try

            myCommand.CommandText = "  CREATE TABLE  IF NOT EXISTS " & bd & ".`contrato_inm` ( " _
                 & " `cod_contra` VARCHAR( 30 ) NOT NULL ," _
                 & " `cod_inm` VARCHAR( 30 ) NOT NULL , " _
                 & " `nit_a` VARCHAR( 15 ) NOT NULL , " _
                 & " `nomb_arr` VARCHAR( 200 ) NOT NULL , " _
                 & " `nit_d` VARCHAR( 15 ) NOT NULL , " _
                 & " `fechaini` DATE NOT NULL DEFAULT  '0000-00-00', " _
                 & " `fechafin` DATE NOT NULL DEFAULT  '0000-00-00', " _
                 & " `valor` DOUBLE NOT NULL , " _
                 & " `cta_valor` VARCHAR( 15 ) NOT NULL , " _
                 & " `por_iva` DECIMAL( 10, 2 ) NOT NULL , " _
                 & " `cta_iva` VARCHAR( 15 ) NOT NULL , " _
                 & " `rtf` DECIMAL( 10, 2 ) NOT NULL , " _
                 & " `cta_rtf` VARCHAR( 15 ) NOT NULL , " _
                 & " `por_comi` DECIMAL( 10, 2 ) NOT NULL , " _
                & " `cc` VARCHAR( 15 ) NOT NULL , " _
                & " `mes_total` DOUBLE NOT NULL , " _
                & " `mes_fact` DOUBLE NOT NULL , " _
                & " `mes_act` DOUBLE NOT NULL , " _
                & " `periodo` VARCHAR( 15 ) NOT NULL , " _
                & " `nitv` VARCHAR( 15 ) NOT NULL , " _
                & " `vmto` INT(4) NOT NULL , " _
                & " `deposito` DOUBLE NOT NULL, " _
                & " `fechaF` DATE NOT NULL ," _
                & " `nitc` VARCHAR( 15 ) NOT NULL , " _
                & " `cta_cli` VARCHAR( 15 ) NOT NULL , " _
                & " `cta_cms` VARCHAR( 15 ) NOT NULL , " _
                & " `dias` int(11) NOT NULL," _
                & " `mov_deposito` DOUBLE NOT NULL, " _
                & " `doc_dep` VARCHAR( 30 ) NOT NULL, " _
                & " `nitc2` VARCHAR( 15 ) NOT NULL, " _
                & " `rtc` DECIMAL( 10, 2 ) NOT NULL," _
                & " `cta_rtc` VARCHAR( 15 ) NOT NULL, " _
                & "  `cont_dp` VARCHAR( 2 ) NOT NULL DEFAULT  'NO'," _
                & " PRIMARY KEY (  `cod_contra` ) " _
                & " ) ENGINE = MYISAM ; "
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try


        Try ' OTROS CONC CONTRATOS
            myCommand.Parameters.Clear()
            myCommand.CommandText = " CREATE TABLE  IF NOT EXISTS " & bd & ".`otcon_contrato` (" _
             & " `codcon` VARCHAR( 30 ) NOT NULL , " _
             & " `item` VARCHAR( 11 ) NOT NULL , " _
             & " `tipo` CHAR( 1 ) NOT NULL , " _
             & "  `descr` VARCHAR( 100 ) NOT NULL ," _
             & "  `valor` DOUBLE NOT NULL , " _
             & " `base` DOUBLE NOT NULL , " _
             & " `cta` VARCHAR( 15 ) NOT NULL , " _
             & " `tcli` VARCHAR( 15 ) NOT NULL , " _
             & " `nitc` VARCHAR( 15 ) NOT NULL, " _
             & " `contb` CHAR( 1 ) NOT NULL DEFAULT  'N', " _
             & " `dia` CHAR( 2 ) NOT NULL DEFAULT  'NO' " _
             & " ) ENGINE = INNODB; "
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        'parametros
        Try
            myCommand.CommandText = "  CREATE TABLE  IF NOT EXISTS " & bd & ".`parcontrato` ( " _
               & " `comentario` TEXT NOT NULL , " _
               & " `ctavent` VARCHAR( 15 ) NOT NULL , " _
               & " `ctaiva` VARCHAR( 15 ) NOT NULL ," _
               & " `ctartf` VARCHAR( 15 ) NOT NULL , " _
               & "  `parf` VARCHAR( 2 ) NOT NULL DEFAULT  'NO', " _
               & " `docf` VARCHAR( 3 ) NOT NULL, " _
               & "  `tipof1` VARCHAR( 4 ) NOT NULL ," _
               & "  `a_f1` BIGINT( 20 ) NOT NULL ," _
               & " `hr1` VARCHAR( 2 ) NOT NULL, " _
               & " `reso1` VARCHAR( 30 ) NOT NULL , " _
               & " `fecexp1` DATE NOT NULL  DEFAULT  '0000-00-00', " _
               & " `feclim1` DATE NOT NULL  DEFAULT  '0000-00-00', " _
               & " `ini1` BIGINT( 20 ) NOT NULL ," _
               & " `fin1` BIGINT( 20 ) NOT NULL , " _
               & "  `pre1` VARCHAR( 10 ) NOT NULL , " _
               & "  `ctacli` VARCHAR( 15 ) NOT NULL,  " _
               & "  `ctacms` VARCHAR( 15 ) NOT NULL,  " _
                & "  `mora` DECIMAL( 10, 6 ),  " _
                & "  `logo` LONGBLOB NULL , " _
                & " `ctaad` VARCHAR( 15 ) NOT NULL ," _
                & " `ctaac` VARCHAR( 15 ) NOT NULL ," _
                & " `editar` VARCHAR( 2 ) NOT NULL DEFAULT  'SI' " _
                & " ) ENGINE = MYISAM ; "
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        'TIPOS DE INMUEBLES
        Try
            myCommand.CommandText = " CREATE TABLE  IF NOT EXISTS " & bd & ".`inm_tipo` (" _
          & " `item` INT NOT NULL AUTO_INCREMENT PRIMARY KEY , " _
          & " `tipo` VARCHAR( 60 ) NOT NULL " _
          & " ) ENGINE = INNODB; "
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        'SERVICIOS
        Try

            myCommand.CommandText = " CREATE TABLE  IF NOT EXISTS " & bd & ".`inm_servicios` (" _
          & " `codigo_inm` VARCHAR( 30 ) NOT NULL , " _
          & " `descrip` VARCHAR( 60 ) NOT NULL , " _
          & " `codigo` VARCHAR( 60 ) NOT NULL , " _
          & " `numero` VARCHAR( 60 ) NOT NULL ," _
          & " `titular` VARCHAR( 100 ) NOT NULL , " _
          & " `observacion` TEXT NOT NULL, " _
          & " `perdoc` VARCHAR( 10 ) NOT NULL ," _
          & " `doc` VARCHAR( 15 ) NOT NULL, " _
          & " `deposito` DOUBLE NOT NULL" _
          & " ) ENGINE = INNODB; "
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        ' DEPENDENCIAS
        Try
            myCommand.CommandText = " CREATE TABLE  IF NOT EXISTS " & bd & ".`inm_dpden` (" _
             & "`codigo_inm` VARCHAR( 30 ) NOT NULL , " _
             & "`descrip` VARCHAR( 100 ) NOT NULL , " _
             & "`espacio` DECIMAL( 10, 2 ) NOT NULL , " _
             & "`umedida` VARCHAR( 5 ) NOT NULL , " _
            & "INDEX (  `codigo_inm` ) " _
            & ") ENGINE = INNODB; "
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        'LLAVES
        Try
            myCommand.CommandText = " CREATE TABLE  IF NOT EXISTS " & bd & ".`inm_llaves` (" _
             & " `codigo_inm` VARCHAR( 30 ) NOT NULL , " _
             & " `sitio` VARCHAR( 100 ) NOT NULL , " _
             & " `cant` BIGINT NOT NULL , " _
             & " `marca` VARCHAR( 60 ) NOT NULL ," _
             & " INDEX (  `codigo_inm` ) " _
             & " ) ENGINE = INNODB; "
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        'PAGOS A SERVICIOS
        Try
            myCommand.CommandText = " CREATE TABLE  IF NOT EXISTS " & bd & ".`inm_servpagos` (" _
             & " `codigo_inm` VARCHAR( 30 ) NOT NULL , " _
             & " `mes` VARCHAR( 60 ) NOT NULL , " _
             & " `servicio` VARCHAR( 60 ) NOT NULL," _
             & "`fecha` DATE NOT NULL , " _
             & "`valor` DOUBLE NOT NULL , " _
             & "`forma` VARCHAR( 100 ) NOT NULL , " _
             & "`perdoc` varchar(10) NOT NULL," _
            & " `doc` varchar(15) NOT NULL," _
            & " `deposito` DOUBLE NOT NULL," _
            & "INDEX (  `codigo_inm` ) " _
            & ") ENGINE = INNODB; "
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        'NOVEDADES
        Try
            myCommand.CommandText = " CREATE TABLE IF NOT EXISTS " & bd & ".`inm_novdad` (" _
          & " `ndoc` varchar(15) NOT NULL, " _
          & " `codigoinm` varchar(30) NOT NULL," _
          & " `nita` varchar(15) NOT NULL, " _
          & " `novedad` text NOT NULL, " _
          & " `fecha` date NOT NULL, " _
          & "`estado` varchar(20) NOT NULL, " _
          & " `proced` text NOT NULL, " _
          & " `fecha_pro` date NOT NULL, " _
          & "`nitv` varchar(15) NOT NULL, " _
          & "`nitp` VARCHAR( 15 ) NOT NULL, " _
          & "`perdoc` VARCHAR( 10 ) NOT NULL , " _
          & " `doc` VARCHAR( 15 ) NOT NULL ," _
          & " `valor` DOUBLE NOT NULL , " _
          & " PRIMARY KEY  (`ndoc`) " _
          & ") ENGINE=InnoDB DEFAULT CHARSET=latin1; "
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Try
            myCommand.CommandText = "CREATE TABLE  IF NOT EXISTS " & bd & ".`inm_galeria` (" _
            & "`id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY ," _
            & "`codinm` VARCHAR( 30 ) NOT NULL , " _
            & "`imagen` LONGBLOB NOT NULL," _
            & " `descr` VARCHAR( 100 ) NOT NULL " _
            & ") ENGINE = INNODB; "
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
       
        'Catch ex As Exception

        'End Try

        Dim per As String
        For i = 1 To 12
            If i < 10 Then
                per = "0" & i
            Else
                per = i
            End If
            Try
                myCommand.CommandText = "  CREATE TABLE  IF NOT EXISTS " & bd & ".facturainm" & per & "(" _
                 & " `doc` VARCHAR( 15 ) NOT NULL , " _
                 & " `num` BIGINT( 10 ) NOT NULL , " _
                 & " `tipodoc` VARCHAR( 4 ) NOT NULL , " _
                 & " `fecha` DATE NOT NULL ," _
                 & " `codcontrato` VARCHAR( 30 ) NOT NULL ," _
                 & " `codinm` VARCHAR( 30 ) NOT NULL , " _
                 & " `nita` VARCHAR( 15 ) NOT NULL , " _
                 & " `noma` VARCHAR( 200 ) NOT NULL , " _
                 & " `nitp` VARCHAR( 15 ) NOT NULL , " _
                 & " `nomp` VARCHAR( 200 ) NOT NULL , " _
                 & " `dias` INT NOT NULL , " _
                 & " `valor` DOUBLE NOT NULL , " _
                 & " `totalp` DOUBLE NOT NULL , " _
                 & " `otrosp` DOUBLE NOT NULL , " _
                 & " `totala` DOUBLE NOT NULL , " _
                 & " `otrosa` DOUBLE NOT NULL , " _
                 & " `por_comi` DECIMAL( 10, 2 ) NOT NULL , " _
                 & " `vcomi` DOUBLE NOT NULL , " _
                 & " `por_iva` DECIMAL( 10, 2 ) NOT NULL , " _
                 & " `iva` DOUBLE NOT NULL ,  " _
                 & " `descripcion` TEXT NOT NULL , " _
                 & " `estado` VARCHAR( 2 ) NOT NULL , " _
                 & " `doc_anul` VARCHAR( 15 ) NOT NULL , " _
                 & " `vmto` INT NOT NULL , " _
                & " PRIMARY KEY (  `doc` ) " _
                & " ) ENGINE = INNODB; "
                myCommand.ExecuteNonQuery()
            Catch ex As Exception
            End Try
        Next

    End Sub
    '********* CARTERA ********************
    Public Sub Cartera(ByVal bd As String)
        myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".`car_par` (`par_fac1` varchar(2) NOT NULL,`par_fac2` varchar(2) NOT NULL,`par_fac3` varchar(2) NOT NULL,`par_fac4` varchar(2) NOT NULL,`par_aju` varchar(2) NOT NULL," _
                              & "`par_rc` varchar(2) NOT NULL,`par_ci` varchar(2) NOT NULL,`par_posf` varchar(2) NOT NULL,`par_int` varchar(2) NOT NULL,`par_cta_caja` varchar(12) NOT NULL,`par_cta_ban` varchar(12) NOT NULL," _
                              & "`par_cta_ret` varchar(12) NOT NULL,`par_cta_des` varchar(12) NOT NULL,`par_cta_iva` varchar(12) NOT NULL,`par_cta_ven` varchar(12) NOT NULL,`par_cta_pos` varchar(12) NOT NULL,`par_cta_cco` varchar(12) NOT NULL," _
                              & "`par_sal_ini` date NOT NULL,`par_blq_cup` varchar(2) NOT NULL,`par_dia_ven` varchar(2) NOT NULL,`par_blq_mor` varchar(2) NOT NULL,`par_blq_exc` varchar(2) NOT NULL,`par_rcb_apr` varchar(2) NOT NULL,`par_nro_rec` varchar(2) NOT NULL," _
                              & "`par_pag_com` varchar(2) NOT NULL,`par_com_var` varchar(2) NOT NULL,`par_env_cor` varchar(2) NOT NULL,`hay_int` VARCHAR( 2 ) NOT NULL DEFAULT 'NO' COMMENT '¿se cobran intereses moratorios?'," _
                              & "`mon_int` decimal(10,6) NOT NULL DEFAULT '0' COMMENT 'monto del interes moratorio'," _
                              & "`tip_int` VARCHAR( 10 ) NOT NULL DEFAULT 'diario' COMMENT 'tipo de interes moratorio',`cta_mor` VARCHAR( 18 ) NOT NULL COMMENT 'cta intereses moratorios',`concomi` VARCHAR( 2 ) NOT NULL DEFAULT  'NO' COMMENT  'Conceptos comisionables por recaudo', `editarcc` VARCHAR( 2 ) NOT NULL DEFAULT  'NO' COMMENT  'Editar conceptos comisionables');"
        myCommand.ExecuteNonQuery()
        '******* TABLAS OTROS DOCUMENTOS DE CTAS X COBRAR ***********
        Dim per As String
        For i = 1 To 12
            If i < 10 Then
                per = "0" & i
            Else
                per = i
            End If
            '******* TABLAS OTROS DOCUMENTOS DE CTAS X COBRAR ***********
            myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".`ot_cpc" & per & "` (`item` bigint(20) NOT NULL,`doc` varchar(15) NOT NULL,`grupo` varchar(2) NOT NULL,`tipo` varchar(4) NOT NULL,`num` bigint(20) NOT NULL,`doc_afec` varchar(15) NOT NULL,`dia` varchar(2) NOT NULL,`periodo` varchar(8) NOT NULL," _
            & "`ciudad` varchar(30) NOT NULL,`concepto` text NOT NULL,`nitc` varchar(20) NOT NULL,`tn` varchar(4) NOT NULL,`codigo` varchar(18) NOT NULL,`descrip` varchar(100) NOT NULL,`debito` double NOT NULL,`credito` double NOT NULL,`base` double NOT NULL default '0',`total` double NOT NULL," _
            & "`tipo_pago` varchar(10) NOT NULL,`cheque` varchar(20) NOT NULL,`banco` varchar(50) NOT NULL,`sucursal` varchar(50) NOT NULL,`ccosto` varchar(15) NOT NULL,`fecha` date NOT NULL,`elaborado` varchar(50) NOT NULL,`autorizado` varchar(50) NOT NULL,`revisado` varchar(50) NOT NULL,`contabilizado` varchar(50) NOT NULL," _
            & "`doc_aj` varchar(30) NOT NULL,`estado` varchar(2) NOT NULL,`abonado` double NOT NULL,`nitv` VARCHAR( 15 ) NOT NULL, `codcon` VARCHAR( 10 ) NOT NULL);"
            myCommand.ExecuteNonQuery()
        Next


        '....COMISION POR RECAUDO CARTERA
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = " CREATE TABLE  IF NOT EXISTS " & bd & ".`comicar` (" _
             & " `nitv` VARCHAR( 15 ) NOT NULL , " _
             & "`codcon` INT( 11 ) NOT NULL , " _
             & "`porcomi` DECIMAL( 10, 2 ) NOT NULL , " _
             & "`r1` INT( 11 ) NOT NULL , " _
             & "`r2` INT( 11 ) NOT NULL " _
             & ") ENGINE = INNODB; "
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
    End Sub
    '************ PROVEEDORES ****************
    Public Sub Proveedores(ByVal bd As String)
        '**** PARAMETROS  COMPRAS
        myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".`par_comp` (`doc_fp` varchar(4) NOT NULL,`doc_aj` varchar(4) NOT NULL,`doc_cpp` varchar(4) NOT NULL,`doc_gas` varchar(4) NOT NULL,`doc_ppf` varchar(4) NOT NULL,`int_con` varchar(2) NOT NULL," _
        & "`cta_caja` varchar(15) NOT NULL,`cta_banco` varchar(15) NOT NULL,`cta_cpp` varchar(15) NOT NULL,`cta_gas` varchar(15) NOT NULL,`cta_com` varchar(15) NOT NULL,`cta_desc` varchar(15) NOT NULL,`cta_inv` varchar(15) NOT NULL,`cta_iva_g` varchar(15) NOT NULL," _
        & "`por_iva_g` decimal(10,2) NOT NULL,`cta_iva_d` varchar(15) NOT NULL,`por_iva_d` decimal(10,2) NOT NULL,`cta_rtf` varchar(15) NOT NULL,`cta_fle` varchar(15) NOT NULL,`cta_seg` varchar(15) NOT NULL,`cta_ppf_c` varchar(15) NOT NULL,`cta_ppf_d` varchar(15) NOT NULL," _
        & "`sol_num_com` varchar(2) NOT NULL,`can_fact` varchar(2) NOT NULL,`fs_aum_inv` varchar(2) NOT NULL,`imp_ap` varchar(2) NOT NULL," _
        & "`format_fp` varchar(10) NOT NULL,`logo_fp` longblob,`format_cpp` varchar(10) NOT NULL,`logo_cpp` longblob,`format_ppf` varchar(10) NOT NULL,`logo_ppf` longblob,`comentario` text NOT NULL,`deci` VARCHAR( 1 ) NOT NULL DEFAULT  'S');"
        myCommand.ExecuteNonQuery()
        '********** TABLA GASTOS *****
        myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".`gastos` (" _
        & "`cod_gas` VARCHAR( 15 ) NOT NULL ,`nom_gas` VARCHAR( 150 ) NOT NULL ,`desc_gas` TEXT NOT NULL ,`por_iva` DECIMAL( 10, 2 ) NOT NULL ,`cta_iva` VARCHAR( 15 ) NOT NULL ,`cta_gas` VARCHAR( 15 ) NOT NULL ," _
        & "PRIMARY KEY ( `cod_gas` ));"
        myCommand.ExecuteNonQuery()
        '*********** FACTURAS Y DETALLES FACTURAS *****************
        Dim per As String
        For i = 1 To 12
            Try
                If i < 10 Then
                    per = "0" & i
                Else
                    per = i
                End If
                '****** TABLAS FACTURAS DE COMPRAS *****************
                myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".`fact_comp" & per & "` (`doc` varchar(15) NOT NULL,`num` bigint(20) NOT NULL,`tipodoc` varchar(4) NOT NULL,`doc_de` char(1) NOT NULL,`nitc` varchar(15) NOT NULL,`usuario` varchar(15) NOT NULL,`fecha` date NOT NULL,`hora` time NOT NULL," _
                & "`anulado` varchar(150) NOT NULL,`doc_afec` varchar(15) NOT NULL,`afecta` varchar(2) NOT NULL,`subtotal` double NOT NULL,`por_desc` decimal(10,2) NOT NULL,`descuento` double NOT NULL,`cta_desc` varchar(15) NOT NULL,`por_rtf` decimal(10,2) NOT NULL,`rtf` double NOT NULL,`cta_rtf` varchar(15) NOT NULL," _
                & "`por_iva` decimal(10,2) NOT NULL,`iva` double NOT NULL,`cta_iva` varchar(15) NOT NULL,`fle` double NOT NULL,`cta_fle` varchar(15) NOT NULL,`seg` double NOT NULL,`cta_seg` varchar(15) NOT NULL,`total` double NOT NULL,`cta_total` varchar(15) NOT NULL," _
                & "`estado` varchar(2) NOT NULL,`observ` text NOT NULL,`vmto` int(11) NOT NULL,`ctoc` varchar(15) NOT NULL," _
                & "`fpago` varchar(15) NOT NULL,`num_ch` varchar(15) NOT NULL,`banco` varchar(50) NOT NULL,`tip_tarj` varchar(2) NOT NULL,`num_tarj` varchar(50) NOT NULL,`desc_otra` varchar(50) NOT NULL," _
                & "`o_con` varchar(2) NOT NULL,`t1` char(1) NOT NULL,`d1` varchar(100) NOT NULL,`v1` double NOT NULL,`cta1` varchar(15) NOT NULL,`t2` char(1) NOT NULL,`d2` varchar(100) NOT NULL,`v2` double NOT NULL,`cta2` varchar(15) NOT NULL,`t3` char(1) NOT NULL,`d3` varchar(100) NOT NULL,`v3` double NOT NULL,`cta3` varchar(15) NOT NULL," _
                & "  `b1` double NOT NULL default '0', " _
                & "  `b2` double NOT NULL default '0', " _
                & "  `b3` double NOT NULL default '0', " _
                & "  `doc1` varchar(25) NOT NULL default ' '," _
                & "  `doc2` varchar(25) NOT NULL default ' ', " _
                & "  `doc3` varchar(25) NOT NULL default ' ', " _
                & "  `valor_aj` DOUBLE NOT NULL COMMENT  'valor ajuste'," _
                & " `por_rtc` decimal(10,2) NOT NULL," _
                & " `rtc` double NOT NULL, " _
                & " `cta_rtc` varchar(15) NOT NULL, " _
                & "PRIMARY KEY  (`doc`));"
                myCommand.ExecuteNonQuery()
                '****** TABLAS DETALLES FACTURAS DE COMPRAS *****************
                myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".`detacomp" & per & "` (`doc` varchar(15) NOT NULL,`item` bigint(20) NOT NULL,`tipo_it` char(1) NOT NULL,`cod_art` varchar(18) NOT NULL,`nom_art` text NOT NULL,`num_bod` int(11) NOT NULL,`cantidad` double NOT NULL," _
                & "`valor` double NOT NULL,`vtotal` double NOT NULL,`por_iva_g` decimal(10,2) NOT NULL,`cta_inv` varchar(15) NOT NULL,`cta_cos` varchar(15) NOT NULL,`cta_gas` varchar(15) NOT NULL,`cta_iva` varchar(15) NOT NULL,`concep` varchar(15) NOT NULL);"
                myCommand.ExecuteNonQuery()
                '******* TABLAS OTROS DOCUMENTOS DE CTAS X PAGAR ***********
                myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".`ot_cpp" & per & "` (`item` bigint(20) NOT NULL,`doc` varchar(15) NOT NULL,`grupo` varchar(2) NOT NULL,`tipo` varchar(4) NOT NULL,`num` bigint(20) NOT NULL,`doc_afec` varchar(15) NOT NULL,`dia` varchar(2) NOT NULL,`periodo` varchar(8) NOT NULL," _
                & "`ciudad` varchar(30) NOT NULL,`concepto` text NOT NULL,`nitc` varchar(20) NOT NULL,`tn` varchar(4) NOT NULL,`codigo` varchar(18) NOT NULL,`descrip` varchar(100) NOT NULL,`debito` double NOT NULL,`credito` double NOT NULL,`base` double NOT NULL default '0',`total` double NOT NULL," _
                & "`tipo_pago` varchar(10) NOT NULL,`cheque` varchar(20) NOT NULL,`banco` varchar(50) NOT NULL,`sucursal` varchar(50) NOT NULL,`ccosto` varchar(15) NOT NULL,`fecha` date NOT NULL,`elaborado` varchar(50) NOT NULL,`autorizado` varchar(50) NOT NULL,`revisado` varchar(50) NOT NULL,`contabilizado` varchar(50) NOT NULL," _
                & "`doc_aj` varchar(30) NOT NULL,`estado` varchar(2) NOT NULL,`abonado` double NOT NULL);"
                myCommand.ExecuteNonQuery()
                '.............. OTROS CONCEPTOS
                myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".`otcon_comp" & per & "` (" _
                  & "`doc` varchar(15) NOT NULL, " _
                  & "`item` int(11) NOT NULL, " _
                  & "`tipo` char(1) NOT NULL, " _
                  & "`descrip` varchar(100) NOT NULL, " _
                  & "`valor` double NOT NULL, " _
                  & "`cta` varchar(15) NOT NULL, " _
                  & "`base` double NOT NULL default '0', " _
                  & "`doc_ant` varchar(25) NOT NULL default ' '," _
                  & "KEY `doc` (`doc`) " _
                & ") ENGINE=InnoDB DEFAULT CHARSET=latin1; "
                myCommand.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Next
        '********* VISTAS DE MOVIMIENTOS DE ARTICULOS CPP PARA LOS INFORMES *********************
        myCommand.CommandText = "CREATE OR REPLACE VIEW vista_deta_cpp AS SELECT * FROM `detacomp01` WHERE 1 " _
        & "UNION SELECT * FROM `detacomp02` WHERE 1 " _
        & "UNION SELECT * FROM `detacomp03` WHERE 1 " _
        & "UNION SELECT * FROM `detacomp04` WHERE 1 " _
        & "UNION SELECT * FROM `detacomp05` WHERE 1 " _
        & "UNION SELECT * FROM `detacomp06` WHERE 1 " _
        & "UNION SELECT * FROM `detacomp07` WHERE 1 " _
        & "UNION SELECT * FROM `detacomp08` WHERE 1 " _
        & "UNION SELECT * FROM `detacomp09` WHERE 1 " _
        & "UNION SELECT * FROM `detacomp10` WHERE 1 " _
        & "UNION SELECT * FROM `detacomp11` WHERE 1 " _
        & "UNION SELECT * FROM `detacomp12` WHERE 1;"
        myCommand.ExecuteNonQuery()
        '********* VISTAS DE MOVIMIENTOS DE CPP PARA LOS INFORMES *********************
        myCommand.CommandText = "CREATE OR REPLACE VIEW vista_ot_cpp AS SELECT * FROM `ot_cpp01` WHERE 1 " _
        & "UNION SELECT * FROM `ot_cpp02` WHERE 1 " _
        & "UNION SELECT * FROM `ot_cpp03` WHERE 1 " _
        & "UNION SELECT * FROM `ot_cpp04` WHERE 1 " _
        & "UNION SELECT * FROM `ot_cpp05` WHERE 1 " _
        & "UNION SELECT * FROM `ot_cpp06` WHERE 1 " _
        & "UNION SELECT * FROM `ot_cpp07` WHERE 1 " _
        & "UNION SELECT * FROM `ot_cpp08` WHERE 1 " _
        & "UNION SELECT * FROM `ot_cpp09` WHERE 1 " _
        & "UNION SELECT * FROM `ot_cpp10` WHERE 1 " _
        & "UNION SELECT * FROM `ot_cpp11` WHERE 1 " _
        & "UNION SELECT * FROM `ot_cpp12` WHERE 1;"
        myCommand.ExecuteNonQuery()
        '********* TABLA ORDENES/PEDIDOS DE COMPRA *********************
        myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".`pedi_comp` (`numero` varchar(15) NOT NULL,`item` bigint(20) NOT NULL,`tipo` varchar(4) NOT NULL,`cod_art` varchar(18) NOT NULL,`nom_art` text NOT NULL,`cantped` double NOT NULL,`cantrec` double NOT NULL," _
        & "`costo` double NOT NULL,`por_desc` decimal(10,2) NOT NULL,`descuento` double NOT NULL,`por_iva` decimal(10,2) NOT NULL,`iva` double NOT NULL,`por_rtf` decimal(10,2) NOT NULL,`rtf` double NOT NULL,`valor` double NOT NULL,`vtotal` double NOT NULL,`fle` double NOT NULL,`nitc` varchar(15) NOT NULL," _
        & "`usuario` varchar(20) NOT NULL,`fechaped` date NOT NULL,`fecharec` date NOT NULL,`observ` text NOT NULL,`cumplido` varchar(2) NOT NULL);"
        myCommand.ExecuteNonQuery()
    End Sub
    '******** nomina ***********************
    Public Sub Nomina(ByVal bd As String)

    End Sub
    '************************************************
    Function bdexiste(ByVal bd As String)
        Dim tabla As New DataTable
        Dim bandera As Integer
        myCommand.CommandText = "show DATABASES;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        bandera = 0
        For i = 0 To tabla.Rows.Count - 1
            If tabla.Rows(i).Item(0) = bd Then
                bandera = 1
                Exit For
            End If
        Next
        Return bandera
    End Function
    Public Sub LlenarGenerales(ByVal nbd As String)
        Dim bda, sql, cad As String
        Dim tabla As New DataTable
        bda = "sae" & LCase(CompaniaActual) & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
        Dim tter, ttdoc As New DataTable
        'LLENAR TABLA TERCEROS
        TercerosTemp(nbd)
        sql = "INSERT INTO " & nbd & ".terceros SELECT * FROM " & bda & ".terceros WHERE nit <>'0';"
        InsertPUC(sql)
        'LLENAR TABLA TIPOS DE DOCUMENTO
        tabla.Clear()
        myCommand.CommandText = "SELECT tipodoc,grupo,descripcion,iniciofc,actualfc FROM " & bda & ".tipdoc;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Dim exi, actual As Integer
        For i = 0 To tabla.Rows.Count - 1
            exi = ExisteDoc(nbd, tabla.Rows(i).Item("tipodoc"))
            If exi = -1 Then 'no existe
                cad = "'" & tabla.Rows(i).Item("tipodoc") & "','" & tabla.Rows(i).Item("grupo") & "','" & tabla.Rows(i).Item("descripcion") & "'," & tabla.Rows(i).Item("iniciofc") & "," & tabla.Rows(i).Item("actualfc")
                sql = "INSERT INTO " & nbd & ".tipdoc Values(" & cad & ", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);"
            Else 'ya existe
                Try
                    actual = Val(tabla.Rows(i).Item("actualfc"))
                    If (actual > exi) And (nbd > bda) Then 'SI se actualiza el actual fc
                        sql = "UPDATE " & nbd & ".tipdoc SET grupo='" & tabla.Rows(i).Item("grupo") & "',descripcion='" & tabla.Rows(i).Item("descripcion") & "',actualfc='" & actual & "' WHERE tipodoc='" & tabla.Rows(i).Item("tipodoc") & "';"
                    Else 'NO se actualiza el actual fc
                        sql = "UPDATE " & nbd & ".tipdoc SET grupo='" & tabla.Rows(i).Item("grupo") & "',descripcion='" & tabla.Rows(i).Item("descripcion") & "' WHERE tipodoc='" & tabla.Rows(i).Item("tipodoc") & "';"
                    End If
                Catch ex As Exception
                    MsgBox(ex.ToString)
                    sql = "UPDATE " & nbd & ".tipdoc SET grupo='" & tabla.Rows(i).Item("grupo") & "',descripcion='" & tabla.Rows(i).Item("descripcion") & "' WHERE tipodoc='" & tabla.Rows(i).Item("tipodoc") & "';"
                End Try
            End If
            InsertPUC(sql)
        Next

        'LLENAR TABLA COBDPEN (cobrar)
        sql = "INSERT INTO " & nbd & ".cobdpen SELECT * FROM " & bda & ".cobdpen WHERE pagado<total;"
        Insertar(sql)
        'LLENAR PARAMETROS DE COMPRAS
        sql = "INSERT INTO " & nbd & ".par_comp SELECT * FROM " & bda & ".par_comp;"
        Insertar(sql)
        'LLENAR PARAMETROS DE CARTERA
        sql = "INSERT INTO " & nbd & ".car_par SELECT * FROM " & bda & ".car_par;"
        Insertar(sql)
        'LLENAR COMISION POR RECAUDO
        sql = "INSERT INTO " & nbd & ".comicar SELECT * FROM " & bda & ".comicar;"
        Insertar(sql)
        'LLENAR TABLA GASTOS
        sql = "INSERT INTO " & nbd & ".gastos SELECT * FROM " & bda & ".gastos;"
        Insertar(sql)
        '***************************************************************
        'LLENAR TABLAS DE IMPUESTOS
        'tabla.Clear()
        'myCommand.CommandText = "SELECT * FROM " & bda & ".con_gral_imp;"
        'myAdapter.SelectCommand = myCommand
        'myAdapter.Fill(tabla)
        'For i = 0 To tabla.Rows.Count - 1
        '    sql = "INSERT INTO " & nbd & ".con_gral_imp VALUES('" & tabla.Rows(i).Item("cod_concep") & "','" & tabla.Rows(i).Item("decrip_gral") & "');"
        '    Insertar(sql)
        'Next
        '//////////////////////////////////
        '... TABLAS DE IMPUESTOS
        sql = " INSERT INTO " & nbd & ".con_gral_imp SELECT * FROM " & bda & ".con_gral_imp;"
        Insertar(sql)
        '...LLENAR IMPUESTOS
        sql = " INSERT INTO " & nbd & ".impuestos SELECT * FROM " & bda & ".impuestos;"
        Insertar(sql)

        'tabla.Clear()
        'myCommand.CommandText = "SELECT * FROM " & bda & ".impuestos;"
        'myAdapter.SelectCommand = myCommand
        'myAdapter.Fill(tabla)
        'For i = 0 To tabla.Rows.Count - 1
        '    sql = "INSERT INTO " & nbd & ".impuestos VALUES(" & tabla.Rows(i).Item("id_imp") & ",'" & tabla.Rows(i).Item("cod_concep") & "','" & tabla.Rows(i).Item("codigo") & "','" & tabla.Rows(i).Item("descrip") & "','" & tabla.Rows(i).Item("codigo") & "'," & DIN(tabla.Rows(i).Item("porce")) & ",'" & tabla.Rows(i).Item("codigo") & "','" & tabla.Rows(i).Item("cuenta") & "','" & tabla.Rows(i).Item("tip_asi") & "');"
        '    Insertar(sql)
        'Next

        'LLENAR TABLA GERENCIAL
        sql = "INSERT INTO " & nbd & ".par_analisis SELECT * FROM " & bda & ".par_analisis;"
        Insertar(sql)
        '***************************************************************
        'LLENAR TABLA GERENCIAL
        sql = "INSERT INTO " & nbd & ".par_analisis SELECT * FROM " & bda & ".par_analisis;"
        Insertar(sql)
        '....
        If FrmPrincipal.cmdOrden.Visible = False Then
            'LLENAR TABLA CTA X PAGAR
            sql = "INSERT INTO " & nbd & ".ctas_x_pagar SELECT * FROM " & bda & ".ctas_x_pagar WHERE pagado<total;"
            Insertar(sql)
        End If
    End Sub
    Function ExisteDoc(ByVal bd As String, ByVal doc As String)
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM " & bd & ".tipdoc WHERE tipodoc='" & doc & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count < 1 Then
            Return -1
        Else
            Try
                'MsgBox(Val(tabla.Rows(0).Item("actualfc").ToString))
                Return Val(tabla.Rows(0).Item("actualfc").ToString)
            Catch ex As Exception
                ' MsgBox(ex.ToString)
                Return 0
            End Try
        End If
    End Function
    Public Sub TercerosTemp(ByVal bd As String)
        myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".temp_terceros (" _
                            & "`nit` varchar(20) NOT NULL DEFAULT '',`dv` varchar(2) NOT NULL,`nombre` varchar(100) NOT NULL DEFAULT '',`apellidos` varchar(50) DEFAULT '.',`tipo` varchar(20) NOT NULL DEFAULT 'CLIENTES',`persona` varchar(20) NOT NULL DEFAULT 'natural',`dir` varchar(100) NOT NULL DEFAULT '(ninguna)'," _
                            & "`pais` varchar(10) NOT NULL,`dept` varchar(10) NOT NULL,`mun` varchar(10) NOT NULL," _
                            & "`telefono` varchar(20) DEFAULT '(ninguno)',  `celular` varchar(20) DEFAULT '(ninguno)', `fax` varchar(20) DEFAULT '(ninguno)', `correo` varchar(150) DEFAULT '(ninguno)', `web` varchar(150) DEFAULT '(ninguno)'," _
                            & "`dia` varchar(2) NOT NULL,`mes` varchar(15) NOT NULL,`contacto` varchar(100) NOT NULL,`telconta` varchar(15) NOT NULL,`cupo` double NOT NULL,`vmto` bigint(20) NOT NULL,`iva` varchar(2) NOT NULL,`retef` varchar(2) NOT NULL,`reteiva` varchar(2) NOT NULL,`reteica` varchar(2) NOT NULL," _
                            & "PRIMARY KEY (`nit`));"
        Try
            myCommand.ExecuteNonQuery()
            myCommand.CommandText = "INSERT INTO " & bd & ".temp_terceros SELECT * FROM " & bda & ".terceros UNION SELECT * FROM " & bda & ".temp_terceros WHERE nit <>'0';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub
    '********* CIERRE DE AÑO CONTABLE***********
    Public Sub Cierre()
        Dim bandera As Integer
        Dim bd As String
        Dim ano As String
        ano = PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
        ano = Val(ano) + 1
        bd = "sae" & LCase(CompaniaActual) & ano
        MiConexion(bda)
        bandera = bdexiste(bd)
        FrmCierreAno.mibarra.Value = 5
        If bandera = 0 Then
            MsgBox("Favor primero cree el nuevo año y luego realice esta operación, Gracias. ", MsgBoxStyle.Information, "SAE Control")
            Exit Sub
        End If
        FrmCierreAno.lbestado.Text = "Iniciando cierre de año..."
        Generales(bd)
        Contabilidad(bd)
        'ESTADOS DE LOS PERIODOS (PARA BLOQUEAR PERIODO INICIAL)
        myCommand.CommandText = "UPDATE " & bd & ".bloq_per SET bloqueado='s' WHERE periodo='00';"
        myCommand.ExecuteNonQuery()
        FrmCierreAno.mibarra.Value = 25
        DocumentoDeCierre()
        LlenarDatos(bd)
        FrmCierreAno.mibarra.Value = 75
        Datosiniciales(bd)
        FrmCierreAno.mibarra.Visible = False
        Cerrar()
        MiConexion(bda)
        Cerrar()
        FrmCierreAno.lbestado.Text = "Cierre Completado.    "
        MsgBox("El cierre de año contable se realizo correctamente. (Al abrir el otro año actualice el catalogo de cuentas).", MsgBoxStyle.Information, "SAE")
        FrmCierreAno.lbestado.Text = ""
    End Sub
    Public Sub cuentas(ByVal nbd As String)
        Try

        Catch ex As Exception

        End Try
    End Sub
    Public Sub DocumentoDeCierre()
        Dim t As New DataTable
        Dim saldo, db, cr As Double
        Dim j As Integer = 0
        '*********************
        myCommand.CommandText = "DELETE FROM " & bda & ".documentos12 WHERE tipodoc='CA';"
        myCommand.ExecuteNonQuery()
        '*************************
        sumadb = 0
        sumacr = 0
        sumasaldo = 0
        FrmCierreAno.lbestado.Text = "Actualizando Catalogo de Cuentas..."
        Dim v As Integer = FrmCierreAno.mibarra.Value
        FrmCierreAno.mibarra.Value = 0
        ActualizarCatalogoCierre(FrmCierreAno.mibarra)
        FrmCierreAno.mibarra.Value = v
        sumadb = 0
        sumacr = 0
        sumasaldo = 0
        FrmCierreAno.lbestado.Text = "Realizando Documento de Cierre..."
        myCommand.CommandText = "SELECT codigo,descripcion,saldo FROM " & bda & ".selpuc WHERE codigo >= '4' AND nivel='Auxiliar' ORDER BY codigo;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t)
        For i = 0 To t.Rows.Count - 1
            Try
                saldo = CDbl(t.Rows(i).Item("saldo"))
            Catch ex As Exception
                saldo = 0
            End Try
            If saldo >= 0 Then 'saldo debito ==> pasa a credito, debito=0
                cr = saldo
                db = 0
            Else 'saldo credito ==> pasa a debito, credito=0
                db = saldo * (-1)
                cr = 0
            End If
            If db <> 0 Or cr <> 0 Then
                j = j + 1
                Insert_Doc_cierre(j, t.Rows(i).Item("codigo"), t.Rows(i).Item("descripcion"), db, cr, (db - cr))
            End If
        Next
    End Sub
    Public Sub Insert_Doc_cierre(ByVal item As Integer, ByVal codigo As String, ByVal des As String, ByVal db As Double, ByVal cr As Double, ByVal sal As Double)
        '/////////////INSERT TABLA DOCUENTOS12///////////////////
        des = "CIERRE " & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6) & " " & des
        des = CambiaCadena(des, 50)
        Dim ano As Integer = Val(PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6))
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?item", item)
        myCommand.Parameters.AddWithValue("?doc", ano)
        myCommand.Parameters.AddWithValue("?tipodoc", "CA")
        myCommand.Parameters.AddWithValue("?periodo", PerActual)
        myCommand.Parameters.AddWithValue("?dia", Now.Day.ToString)
        myCommand.Parameters.AddWithValue("?centro", "0")
        myCommand.Parameters.AddWithValue("?desc", des)
        myCommand.Parameters.AddWithValue("?debito", db)
        myCommand.Parameters.AddWithValue("?credito", cr)
        myCommand.Parameters.AddWithValue("?codigo", codigo)
        myCommand.Parameters.AddWithValue("?base", 0)
        myCommand.Parameters.AddWithValue("?diasv", 0)
        myCommand.Parameters.AddWithValue("?fechaven", "00/00/0000")
        myCommand.Parameters.AddWithValue("?nit", "0")
        myCommand.Parameters.AddWithValue("?cheque", "")
        myCommand.Parameters.AddWithValue("?modulo", "contabilidad")
        myCommand.CommandText = "INSERT INTO " & bda & ".documentos12 VALUES(?item,?doc,?tipodoc,?periodo,?dia,?centro,?desc,?debito,?credito,?codigo,?base,?diasv,?fechaven,?nit,?cheque,?modulo);"
        myCommand.ExecuteNonQuery()
        '/////////////ACTUALIZAR SALDO FINAL///////////////////
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?saldo", "0")
        myCommand.Parameters.AddWithValue("?debito", db)
        myCommand.Parameters.AddWithValue("?credito", cr)
        myCommand.Parameters.AddWithValue("?saldo12", sal)
        myCommand.CommandText = "UPDATE " & bda & ".selpuc SET saldo=?saldo,debito12=debito12 + ?debito,credito12= credito12 + ?credito,saldo12=saldo12 + ?saldo12  WHERE codigo='" & codigo & "';"
        myCommand.ExecuteNonQuery()
    End Sub
    Public Sub llenarAuditoria(ByVal nbd As String)
        Dim bda, sql As String
        bda = "sae" & LCase(CompaniaActual) & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
        'LLENAR Audioria compras
        sql = "TRUNCATE TABLE " & nbd & ".audi_parcom; INSERT INTO " & nbd & ".audi_parcom SELECT * FROM " & bda & ".audi_parcom;"
        Insertar(sql)
        'LLENAR Audioria fact
        sql = "TRUNCATE TABLE " & nbd & ".audi_parfac; INSERT INTO " & nbd & ".audi_parfac SELECT * FROM " & bda & ".audi_parfac;"
        Insertar(sql)
        'LLENAR Audioria otros documentos
        sql = "TRUNCATE TABLE " & nbd & ".aud_otdoc; INSERT INTO " & nbd & ".aud_otdoc SELECT * FROM " & bda & ".aud_otdoc;"
        Insertar(sql)
    End Sub
    Public Sub LlenarDatos(ByVal nbd As String)
        FrmCierreAno.lbestado.Text = "Ajustes de Datos..."
        LlenarGenerales(nbd)
        Dim bda, sql As String
        bda = "sae" & LCase(CompaniaActual) & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
        Dim tnc, tsp, ttri As New DataTable
        'LLENAR TABLA NIVELES DE CUENTAS
        sql = "TRUNCATE TABLE " & nbd & ".parcontab; INSERT INTO " & nbd & ".parcontab SELECT * FROM " & bda & ".parcontab;"
        Insertar(sql)
        'LLENAR TABLA SELPUC
        TempSelpuc(nbd)
        'LLENAR CUENTAS TRIBUTARIAS
        sql = "TRUNCATE TABLE " & nbd & ".tributarios; INSERT INTO " & nbd & ".tributarios SELECT * FROM " & bda & ".tributarios;"
        Insertar(sql)
        'LLENAR CENTRO DE COSTOS
        sql = "TRUNCATE TABLE " & nbd & ".centrocostos; INSERT INTO " & nbd & ".centrocostos SELECT * FROM " & bda & ".centrocostos;"
        Insertar(sql)
        'LLENAR PARAMETROS DE OTROS DOCUMENTOS
        sql = "TRUNCATE TABLE " & nbd & ".parotdoc; INSERT INTO " & nbd & ".parotdoc SELECT * FROM " & bda & ".parotdoc;"
        Insertar(sql)

    End Sub
    Public Sub TempSelpuc(ByVal bd As String)
        Try
            Dim t As New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT * FROM " & bda & ".selpuc ORDER BY codigo;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(t)
            Dim sq As String
            For i = 0 To t.Rows.Count - 1
                sq = "INSERT INTO " & bd & ".selpuc VALUES ('" & t.Rows(i).Item("codigo") & "', '" & t.Rows(i).Item("descripcion") & "', '" & t.Rows(i).Item("naturaleza") & "', '" & t.Rows(i).Item("nivel") & "', '" & t.Rows(i).Item("tipo") & "', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,'" & t.Rows(i).Item("tipo_saldo") & "');"
                Insertar(sq)
            Next
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub Insertar(ByVal sql As String)
        Try
            myCommand.CommandText = sql
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            'MsgBox(sql & " Error: " & ex.ToString)
        End Try
    End Sub
    Public Sub Datosiniciales(ByVal bd As String)
        FrmCierreAno.lbestado.Text = "Saldos Iniciales del proximo año..."
        Try
            Dim tsp As New DataTable
            Dim mes As String
            '********** VACIAR TABLA SI HAY DATOS **********************
            myCommand.CommandText = "TRUNCATE " & bd & ".documentos00;"
            myCommand.ExecuteNonQuery()
            '***********************************************************
            For j = 0 To 12
                If j < 10 Then
                    mes = "0" & j
                Else
                    mes = j
                End If
                myCommand.Parameters.Clear()
                tsp.Clear()
                myCommand.CommandText = "SELECT * from " & bda & ".documentos" & mes & " WHERE codigo < '4' ORDER BY periodo,dia,tipodoc,doc,item;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tsp)
                For i = 0 To tsp.Rows.Count - 1
                    If Existe(tsp.Rows(i).Item("codigo"), tsp.Rows(i).Item("nit"), bd) = 0 Then
                        myCommand.Parameters.Clear()
                        myCommand.Parameters.AddWithValue("?item", i + 1)
                        myCommand.Parameters.AddWithValue("?doc", 1)
                        myCommand.Parameters.AddWithValue("?tipodoc", "SI")
                        myCommand.Parameters.AddWithValue("?periodo", PerActual)
                        myCommand.Parameters.AddWithValue("?dia", Now.Day.ToString)
                        myCommand.Parameters.AddWithValue("?centro", "0")
                        myCommand.Parameters.AddWithValue("?desc", tsp.Rows(i).Item("descri"))
                        myCommand.Parameters.AddWithValue("?debito", tsp.Rows(i).Item("debito"))
                        myCommand.Parameters.AddWithValue("?credito", tsp.Rows(i).Item("credito"))
                        myCommand.Parameters.AddWithValue("?codigo", tsp.Rows(i).Item("codigo"))
                        myCommand.Parameters.AddWithValue("?base", 0)
                        myCommand.Parameters.AddWithValue("?diasv", 0)
                        myCommand.Parameters.AddWithValue("?fechaven", "00/00/0000")
                        myCommand.Parameters.AddWithValue("?nit", tsp.Rows(i).Item("nit"))
                        myCommand.Parameters.AddWithValue("?cheque", tsp.Rows(i).Item("cheque"))
                        myCommand.Parameters.AddWithValue("?modulo", "contabilidad")
                        myCommand.CommandText = "INSERT INTO " & bd & ".documentos00 VALUES(?item,?doc,?tipodoc,?periodo,?dia,?centro,?desc,?debito,?credito,?codigo,?base,?diasv,?fechaven,?nit,?cheque,?modulo);"
                        myCommand.ExecuteNonQuery()
                        'If mes = "01" Then MsgBox("INSERT==>NIT:" & tsp.Rows(i).Item("nit") & "   CODIGO:" & tsp.Rows(i).Item("codigo"))
                    Else
                        myCommand.Parameters.Clear()
                        myCommand.Parameters.AddWithValue("?debito", tsp.Rows(i).Item("debito"))
                        myCommand.Parameters.AddWithValue("?credito", tsp.Rows(i).Item("credito"))
                        myCommand.CommandText = "UPDATE " & bd & ".documentos00 SET debito=debito + ?debito, credito=credito + ?credito WHERE codigo='" & tsp.Rows(i).Item("codigo") & "' AND nit='" & tsp.Rows(i).Item("nit") & "';"
                        myCommand.ExecuteNonQuery()
                        'If mes = "01" Then MsgBox("UPDATE==>NIT:" & tsp.Rows(i).Item("nit") & "   CODIGO:" & tsp.Rows(i).Item("codigo"))
                    End If
                Next
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Function Existe(ByVal codigo As String, ByVal nit As String, ByVal bd As String)
        Dim t As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT * from " & bd & ".documentos00 WHERE codigo ='" & codigo & "' AND nit='" & nit & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t)
        If t.Rows.Count = 0 Then
            Return 0
        Else
            Return 1
        End If
    End Function
    '***********************************************
    Public sumadb, sumacr, sumasaldo As Double
    Public Sub ActualizarCatalogoCierre(ByVal mibarra As ProgressBar)
        Dim tabla As New DataTable
        Dim barra, baraux As Double
        myCommand.CommandText = "SELECT codigo,saldo00 FROM selpuc WHERE nivel='Auxiliar' ORDER BY codigo desc;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        barra = 100 / tabla.Rows.Count
        ' MsgBox(barra)
        For i = 0 To tabla.Rows.Count - 1
            CalcularSaldo(tabla.Rows(i).Item("codigo"))
            For j = 0 To 12
                If j < 10 Then
                    Calcular("0" & j, tabla.Rows(i).Item("codigo"))
                Else
                    Calcular(j, tabla.Rows(i).Item("codigo"))
                End If
            Next
            myCommand.Parameters.Clear()
            Try
                myCommand.Parameters.AddWithValue("?sal", CDbl(sumasaldo))
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?sal", "0")
            End Try
            myCommand.CommandText = "UPDATE selpuc SET saldo=?sal WHERE codigo='" & tabla.Rows(i).Item("codigo") & "';"
            myCommand.ExecuteNonQuery()
            If mibarra.Value + barra < 98 Then
                baraux = baraux + barra
                If baraux >= 1 Then
                    mibarra.Value = mibarra.Value + baraux
                    baraux = 0
                End If
            Else
                mibarra.Value = 95
            End If
        Next
        mibarra.Value = 100
        mibarra.Visible = False
        'Me.Cursor = Cursors.Default
    End Sub
    Public Sub CalcularSaldo(ByVal micuenta As String)
        Dim tabla As New DataTable
        '///////////CALCULAR SALDO INICIAL //////////////////////
        myCommand.CommandText = "SELECT sum(saldo00) FROM selpuc WHERE codigo like '" & micuenta & "%' and nivel='Auxiliar';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Try
            sumasaldo = tabla.Rows(0).Item(0)
        Catch ex As Exception
            sumasaldo = 0
        End Try
        myCommand.Parameters.Clear()
        Try
            myCommand.Parameters.AddWithValue("?sal", CDbl(sumasaldo))
        Catch ex As Exception
            myCommand.Parameters.AddWithValue("?sal", "0")
        End Try
        '/////////////ACTUALIZAR SALDO INICIAL///////////////////
        myCommand.CommandText = "UPDATE selpuc SET saldo00=?sal WHERE codigo='" & micuenta & "';"
        myCommand.ExecuteNonQuery()
    End Sub
    Public Sub Calcular(ByVal mitabla As String, ByVal cuenta As String)
        If mitabla = "00" Then
            sumasaldo = 0
        End If
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT sum(debito),sum(credito) FROM documentos" & mitabla & " WHERE codigo like '" & cuenta & "%';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Try
            sumadb = tabla.Rows(0).Item(0)
        Catch ex As Exception
            sumadb = 0
        End Try
        Try
            sumacr = tabla.Rows(0).Item(1)
        Catch ex As Exception
            sumacr = 0
        End Try
        sumasaldo = sumasaldo + (sumadb - sumacr)
        '**********************************************
        ActualizarSelPuc(cuenta, "debito" & mitabla, "credito" & mitabla, "saldo" & mitabla)
    End Sub
    Public Sub ActualizarSelPuc(ByVal cuenta As String, ByVal db As String, ByVal cr As String, ByVal sa As String)
        myCommand.Parameters.Clear()
        Try
            myCommand.Parameters.AddWithValue("?dbto", CDbl(sumadb))
        Catch ex As Exception
            myCommand.Parameters.AddWithValue("?dbto", "0")
        End Try
        Try
            myCommand.Parameters.AddWithValue("?crto", CDbl(sumacr))
        Catch ex As Exception
            myCommand.Parameters.AddWithValue("?crto", "0")
        End Try
        Try
            myCommand.Parameters.AddWithValue("?sal", CDbl(sumasaldo))
        Catch ex As Exception
            myCommand.Parameters.AddWithValue("?sal", "0")
        End Try
        Try
            myCommand.CommandText = "UPDATE selpuc SET " & db & "=?dbto," & cr & "=?crto," & sa & "=?sal " _
                              & " WHERE codigo='" & cuenta & "';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    '********* CIERRE DE AÑO INVENTARIOS***********
    Public Sub CierreInventarios()
        Dim bandera As Integer
        Dim bd As String
        Dim ano As String
        ano = PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
        ano = Val(ano) + 1
        bd = "sae" & LCase(CompaniaActual) & ano
        MiConexion("sae")
        bandera = bdexiste(bd)
        FrmCirreInv.mibarra.Value = 5
        If bandera = 0 Then
            MsgBox("Favor primero cree el nuevo año y luego realice esta operación, Gracias. ", MsgBoxStyle.Information, "SAE Control")
            Exit Sub
        End If
        FrmCirreInv.mibarra.Value = 15
        Generales(bd)
        FrmCirreInv.mibarra.Value = 25
        Inventario(bd)
        FrmCirreInv.mibarra.Value = 35
        LlenarInventarios2(bd)
        FrmCirreInv.mibarra.Value = 99
        FrmCirreInv.Cursor = Cursors.Default
        FrmCirreInv.mibarra.Visible = False
        MiConexion(bda)
        Cerrar()
        If FrmPrincipal.cmdAuditoria.Visible = True Then
            Guar_MovUser("INVENTARIO", "CIERRE ANUAL DE INVENTARIO ", "", "", "")
        End If
        MsgBox("El cierre de año de inventarios se realizo correctamente. ", MsgBoxStyle.Information, "SAE Cierre de Inventarios")

    End Sub
    Public Sub LlenarInventarios2(ByVal nbd As String)
        Dim tabla_ci As New DataTable
        Dim mi_per As String
        Dim sql As String = ""
        myCommand.CommandText = "SELECT * FROM " & bda & ".con_inv WHERE periodo='12' ORDER BY codart;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla_ci)
        Dim margen As Double
        For i = 0 To tabla_ci.Rows.Count - 1
            sql = "DELETE FROM " & nbd & ".con_inv WHERE codart='" & tabla_ci.Rows(i).Item("codart") & "' AND periodo='00'"
            Insertar(sql)
            mi_per = "00"
            Try
                margen = CDec(tabla_ci.Rows(i).Item("margen").ToString)
            Catch ex As Exception
                margen = 0
            End Try
            sql = "INSERT INTO " & nbd & ".con_inv VALUES('" & tabla_ci.Rows(i).Item("codart") & "','" & mi_per & "','" & DIN(tabla_ci.Rows(i).Item("costuni")) & "','" & DIN(tabla_ci.Rows(i).Item("costprom")) & "','" & DIN(tabla_ci.Rows(i).Item("costmoe")) & "','" & DIN(tabla_ci.Rows(i).Item("otro")) & "','" & DIN(margen) & "','" & tabla_ci.Rows(i).Item("base") & "'," _
            & "'" & DIN(tabla_ci.Rows(i).Item("precio1")) & "','" & DIN(tabla_ci.Rows(i).Item("precio2")) & "','" & DIN(tabla_ci.Rows(i).Item("precio3")) & "','" & DIN(tabla_ci.Rows(i).Item("precio4")) & "','" & DIN(tabla_ci.Rows(i).Item("precio5")) & "','" & DIN(tabla_ci.Rows(i).Item("precio6")) & "'," _
            & "'" & tabla_ci.Rows(i).Item("cue_inv") & "','" & tabla_ci.Rows(i).Item("cue_cos") & "','" & tabla_ci.Rows(i).Item("cue_ing") & "','" & tabla_ci.Rows(i).Item("cue_iva_v") & "','" & tabla_ci.Rows(i).Item("cue_iva_c") & "','" & tabla_ci.Rows(i).Item("cue_dev") & "'," _
            & "'" & DIN(tabla_ci.Rows(i).Item("saldoi")) & "','" & DIN(tabla_ci.Rows(i).Item("vent")) & "','" & DIN(tabla_ci.Rows(i).Item("vsal")) & "','" & DIN(tabla_ci.Rows(i).Item("vaju")) & "'," _
            & "'" & DIN(tabla_ci.Rows(i).Item("cant1")) & "','" & DIN(tabla_ci.Rows(i).Item("cant2")) & "','" & DIN(tabla_ci.Rows(i).Item("cant3")) & "','" & DIN(tabla_ci.Rows(i).Item("cant4")) & "','" & DIN(tabla_ci.Rows(i).Item("cant5")) & "','" & DIN(tabla_ci.Rows(i).Item("cant6")) & "','" & DIN(tabla_ci.Rows(i).Item("cant7")) & "','" & DIN(tabla_ci.Rows(i).Item("cant8")) & "','" & DIN(tabla_ci.Rows(i).Item("cant9")) & "','" & DIN(tabla_ci.Rows(i).Item("cant10")) & "'," _
            & "'" & DIN(tabla_ci.Rows(i).Item("cant11")) & "','" & DIN(tabla_ci.Rows(i).Item("cant12")) & "','" & DIN(tabla_ci.Rows(i).Item("cant13")) & "','" & DIN(tabla_ci.Rows(i).Item("cant14")) & "','" & DIN(tabla_ci.Rows(i).Item("cant15")) & "','" & DIN(tabla_ci.Rows(i).Item("cant16")) & "','" & DIN(tabla_ci.Rows(i).Item("cant17")) & "','" & DIN(tabla_ci.Rows(i).Item("cant18")) & "','" & DIN(tabla_ci.Rows(i).Item("cant19")) & "','" & DIN(tabla_ci.Rows(i).Item("cant20")) & "'," _
            & "'" & DIN(tabla_ci.Rows(i).Item("cant21")) & "','" & DIN(tabla_ci.Rows(i).Item("cant22")) & "','" & DIN(tabla_ci.Rows(i).Item("cant23")) & "','" & DIN(tabla_ci.Rows(i).Item("cant24")) & "','" & DIN(tabla_ci.Rows(i).Item("cant25")) & "','" & DIN(tabla_ci.Rows(i).Item("cant26")) & "','" & DIN(tabla_ci.Rows(i).Item("cant27")) & "','" & DIN(tabla_ci.Rows(i).Item("cant28")) & "','" & DIN(tabla_ci.Rows(i).Item("cant29")) & "','" & DIN(tabla_ci.Rows(i).Item("cant30")) & "'" _
            & ");"
            Insertar(sql)
        Next
    End Sub
    Public Sub LlenarInventarios(ByVal nbd As String)
        LlenarGenerales(nbd)
        FrmCirreInv.mibarra.Value = 70
        Dim sql As String
        'LLENAR LOS PARAMETROS DE INVENTARIOS
        sql = "TRUNCATE TABLE " & nbd & ".parinven; INSERT INTO " & nbd & ".parinven SELECT * FROM " & bda & ".parinven;"
        Insertar(sql)
        'LLENAR ARTICULOS
        sql = "TRUNCATE TABLE " & nbd & ".articulos; INSERT INTO " & nbd & ".articulos SELECT * FROM " & bda & ".articulos;"
        Insertar(sql)
        'LLENAR BODEGAS
        sql = "TRUNCATE TABLE " & nbd & ".bodegas; INSERT INTO " & nbd & ".bodegas SELECT * FROM " & bda & ".bodegas;"
        Insertar(sql)
        'LLENAR LISTAS DE PRECIOS
        sql = "TRUNCATE TABLE " & nbd & ".listasprec; INSERT INTO " & nbd & ".listasprec SELECT * FROM " & bda & ".listasprec;"
        Insertar(sql)
        'VACIAR CON_INV (CONSOLIDADOS INVENTARIOS)
        sql = "TRUNCATE TABLE " & nbd & ".con_inv;"
        Insertar(sql)
        'LLENAR CON_INV (CONSOLIDADOS INVENTARIOS)
        Dim tabla_ci As New DataTable
        Dim mi_per As String
        myCommand.CommandText = "SELECT * FROM " & bda & ".con_inv WHERE periodo='12' ORDER BY codart;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla_ci)
        Dim margen As Double
        For i = 0 To tabla_ci.Rows.Count - 1
            For j = 0 To 12
                If j < 10 Then
                    mi_per = "0" & j
                Else
                    mi_per = j
                End If
                Try
                    margen = CDec(tabla_ci.Rows(i).Item("margen").ToString)
                Catch ex As Exception
                    margen = 0
                End Try
                sql = "INSERT INTO " & nbd & ".con_inv VALUES('" & tabla_ci.Rows(i).Item("codart") & "','" & mi_per & "','" & DIN(tabla_ci.Rows(i).Item("costuni")) & "','" & DIN(tabla_ci.Rows(i).Item("costprom")) & "','" & DIN(tabla_ci.Rows(i).Item("costmoe")) & "','" & DIN(tabla_ci.Rows(i).Item("otro")) & "','" & DIN(margen) & "','" & tabla_ci.Rows(i).Item("base") & "'," _
                & "'" & DIN(tabla_ci.Rows(i).Item("precio1")) & "','" & DIN(tabla_ci.Rows(i).Item("precio2")) & "','" & DIN(tabla_ci.Rows(i).Item("precio3")) & "','" & DIN(tabla_ci.Rows(i).Item("precio4")) & "','" & DIN(tabla_ci.Rows(i).Item("precio5")) & "','" & DIN(tabla_ci.Rows(i).Item("precio6")) & "'," _
                & "'" & tabla_ci.Rows(i).Item("cue_inv") & "','" & tabla_ci.Rows(i).Item("cue_cos") & "','" & tabla_ci.Rows(i).Item("cue_ing") & "','" & tabla_ci.Rows(i).Item("cue_iva_v") & "','" & tabla_ci.Rows(i).Item("cue_iva_c") & "','" & tabla_ci.Rows(i).Item("cue_dev") & "'," _
                & "'" & DIN(tabla_ci.Rows(i).Item("saldoi")) & "','" & DIN(tabla_ci.Rows(i).Item("vent")) & "','" & DIN(tabla_ci.Rows(i).Item("vsal")) & "','" & DIN(tabla_ci.Rows(i).Item("vaju")) & "'," _
                & "'" & DIN(tabla_ci.Rows(i).Item("cant1")) & "','" & DIN(tabla_ci.Rows(i).Item("cant2")) & "','" & DIN(tabla_ci.Rows(i).Item("cant3")) & "','" & DIN(tabla_ci.Rows(i).Item("cant4")) & "','" & DIN(tabla_ci.Rows(i).Item("cant5")) & "','" & DIN(tabla_ci.Rows(i).Item("cant6")) & "','" & DIN(tabla_ci.Rows(i).Item("cant7")) & "','" & DIN(tabla_ci.Rows(i).Item("cant8")) & "','" & DIN(tabla_ci.Rows(i).Item("cant9")) & "','" & DIN(tabla_ci.Rows(i).Item("cant10")) & "'," _
                & "'" & DIN(tabla_ci.Rows(i).Item("cant11")) & "','" & DIN(tabla_ci.Rows(i).Item("cant12")) & "','" & DIN(tabla_ci.Rows(i).Item("cant13")) & "','" & DIN(tabla_ci.Rows(i).Item("cant14")) & "','" & DIN(tabla_ci.Rows(i).Item("cant15")) & "','" & DIN(tabla_ci.Rows(i).Item("cant16")) & "','" & DIN(tabla_ci.Rows(i).Item("cant17")) & "','" & DIN(tabla_ci.Rows(i).Item("cant18")) & "','" & DIN(tabla_ci.Rows(i).Item("cant19")) & "','" & DIN(tabla_ci.Rows(i).Item("cant20")) & "'," _
                & "'" & DIN(tabla_ci.Rows(i).Item("cant21")) & "','" & DIN(tabla_ci.Rows(i).Item("cant22")) & "','" & DIN(tabla_ci.Rows(i).Item("cant23")) & "','" & DIN(tabla_ci.Rows(i).Item("cant24")) & "','" & DIN(tabla_ci.Rows(i).Item("cant25")) & "','" & DIN(tabla_ci.Rows(i).Item("cant26")) & "','" & DIN(tabla_ci.Rows(i).Item("cant27")) & "','" & DIN(tabla_ci.Rows(i).Item("cant28")) & "','" & DIN(tabla_ci.Rows(i).Item("cant29")) & "','" & DIN(tabla_ci.Rows(i).Item("cant30")) & "'" _
                & ");"
                Insertar(sql)
            Next j
        Next i
    End Sub
    '*************** CIERRE DE AÑO INMOBILIARIA **************
    Public Sub CierreInmobiliaria()
        Dim bandera As Integer
        Dim bd As String
        Dim ano As String
        ano = PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
        ano = Val(ano) + 1
        bd = "sae" & LCase(CompaniaActual) & ano
        MiConexion("sae")
        bandera = bdexiste(bd)
        FrmCierreInm.mibarra.Value = 5
        If bandera = 0 Then
            MsgBox("Favor primero cree el nuevo año y luego realice esta operación, Gracias. ", MsgBoxStyle.Information, "SAE Control")
            Exit Sub
        End If
        FrmCierreInm.mibarra.Value = 25
        Inmobiliaria(bd)
        FrmCierreInm.mibarra.Value = 35
        LlenarInmobiliaria2(bd)
        FrmCierreInm.mibarra.Value = 99
        FrmCierreInm.Cursor = Cursors.Default
        FrmCierreInm.mibarra.Visible = False
        MiConexion(bda)
        Cerrar()
        MsgBox("El cierre de año del modulo inmobiliario se realizo correctamente. ", MsgBoxStyle.Information, "SAE Cierre Inmobiliarias")
    End Sub
    Public Sub LlenarInmobiliaria(ByVal nbd As String)
        'FrmCierreInm.mibarra.Value = 70
        Dim sql As String
        'LLENAR LOS PARAMETROS DE INMOBILIARIA
        sql = "TRUNCATE TABLE " & nbd & ".parcontrato; INSERT INTO " & nbd & ".parcontrato SELECT * FROM " & bda & ".parcontrato;"
        Insertar(sql)
    End Sub
    Public Sub LlenarInmobiliaria2(ByVal nbd As String)
        Dim sql2 As String = ""
        ' CARGAR INMUEBLES 
        sql2 = "TRUNCATE TABLE " & nbd & ".inmuebles; INSERT INTO " & nbd & ".inmuebles SELECT * FROM " & bda & ".inmuebles ;"
        Insertar(sql2)

        ' CARGAR TERCEROS INMOBILIARIA
        sql2 = ""
        sql2 = "TRUNCATE TABLE " & nbd & ".tercerosinm; INSERT INTO " & nbd & ".tercerosinm SELECT * FROM " & bda & ".tercerosinm;"
        Insertar(sql2)

        ' CARGAR contratos INMOBILIARIA
        sql2 = ""
        sql2 = "TRUNCATE TABLE " & nbd & ".contrato_inm; INSERT INTO " & nbd & ".contrato_inm SELECT * FROM " & bda & ".contrato_inm WHERE mes_total>mes_fact;"
        Insertar(sql2)

        ' CARGAR Otccontratos INMOBILIARIA
        sql2 = ""
        sql2 = "TRUNCATE TABLE " & nbd & ".otcon_contrato; INSERT INTO " & nbd & ".otcon_contrato SELECT * FROM " & bda & ".otcon_contrato"
        Insertar(sql2)

        ' CARGAR TipoInm INMOBILIARIA
        sql2 = ""
        sql2 = "TRUNCATE TABLE " & nbd & ".inm_tipo; INSERT INTO " & nbd & ".inm_tipo SELECT * FROM " & bda & ".inm_tipo"
        Insertar(sql2)

        ' CARGAR InmServ INMOBILIARIA
        sql2 = ""
        sql2 = "TRUNCATE TABLE " & nbd & ".inm_servicios; INSERT INTO " & nbd & ".inm_servicios SELECT * FROM " & bda & ".inm_servicios "
        Insertar(sql2)

        ' CARGAR Inmdpden INMOBILIARIA
        sql2 = ""
        sql2 = "TRUNCATE TABLE " & nbd & ".inm_dpden; INSERT INTO " & nbd & ".inm_dpden SELECT * FROM " & bda & ".inm_dpden "
        Insertar(sql2)

        ' CARGAR Inmllaves INMOBILIARIA
        sql2 = ""
        sql2 = "TRUNCATE TABLE " & nbd & ".inm_llaves; INSERT INTO " & nbd & ".inm_llaves SELECT * FROM " & bda & ".inm_llaves "
        Insertar(sql2)

        ' CARGAR pagos de serv INMOBILIARIA
        sql2 = ""
        sql2 = "TRUNCATE TABLE " & nbd & ".inm_servpagos; INSERT INTO " & nbd & ".inm_servpagos SELECT * FROM " & bda & ".inm_servpagos "
        Insertar(sql2)

        ' CARGAR pagos de serv INMOBILIARIA
        sql2 = ""
        sql2 = "TRUNCATE TABLE " & nbd & ".inm_novdad; INSERT INTO " & nbd & ".inm_novdad SELECT * FROM " & bda & ".inm_novdad where estado='PENDIENTE'"
        Insertar(sql2)

        ' CARGAR galeria INMOBILIARIA
        sql2 = ""
        sql2 = "TRUNCATE TABLE " & nbd & ".inm_galeria; INSERT INTO " & nbd & ".inm_galeria SELECT * FROM " & bda & ".inm_galeria "
        Insertar(sql2)

    End Sub

    '********************************************
    Public Sub CrearTablaOT_DOC()
        MiConexion(bda)
        Dim tabla As String = ""
        For i = 1 To 12
            If i < 10 Then
                tabla = bda & ".ot_doc0" & i
            Else
                tabla = bda & ".ot_doc" & i
            End If
            Try
                myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & tabla & " (`item` bigint(20) NOT NULL,`doc` varchar(15) NOT NULL,`grupo` varchar(2) NOT NULL,`tipo` varchar(4) NOT NULL,`num` bigint(20) NOT NULL,`doc_afec` varchar(15) NOT NULL,`dia` varchar(2) NOT NULL," _
                                     & " `periodo` varchar(8) NOT NULL,`ciudad` varchar(30) NOT NULL,`concepto` text NOT NULL,`nitc` varchar(20) NOT NULL,`tn` varchar(4) NOT NULL,`codigo` varchar(18) NOT NULL,`descrip` varchar(100) NOT NULL,`debito` double NOT NULL," _
                                     & "`credito` double NOT NULL,`base` double NOT NULL,`total` double NOT NULL,`efectivo` char(1) NOT NULL,`cheque` varchar(20) NOT NULL,`banco` varchar(50) NOT NULL,`sucursal` varchar(50) NOT NULL,`ccosto` int(11) NOT NULL,`fecha` date NOT NULL,`elaborado` varchar(50) NOT NULL,`autorizado` varchar(50) NOT NULL,`revisado` varchar(50) NOT NULL,`contabilizado` varchar(50) NOT NULL," _
                                     & "`doc_aj` varchar(30) NOT NULL );"
                myCommand.ExecuteNonQuery()
            Catch ex As Exception
            End Try
            Try
                myCommand.Parameters.Clear()
                myCommand.CommandText = "ALTER TABLE " & tabla & " ADD `base` DOUBLE NOT NULL DEFAULT '0' AFTER `credito` ;"
                myCommand.ExecuteNonQuery()
            Catch ex As Exception
            End Try
        Next
        Cerrar()
    End Sub
    '*******************************************
    '****** MODIFICAR CENTROS DE COSTOS *****************
    Public Sub MoficarCC()
        '***************************
        Try
            '*************************************************
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT DATA_TYPE " _
            & "FROM(Information_Schema.Columns) " _
            & "WHERE table_schema='" & bda & "' " _
            & "AND table_name='centrocostos' " _
            & "GROUP BY Table_Name " _
            & "ORDER BY Table_Name"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If Trim(tabla.Rows(0).Item("DATA_TYPE").ToString) = "varchar" Then Exit Sub
            'MsgBox("no es igual")
        Catch ex As Exception
            'MsgBox(ex.ToString)
            Exit Sub
        End Try
        '**************************
        Dim per As String = ""
        '********* GENERAL *****************
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "ALTER TABLE `centrocostos` ADD `nivel` VARCHAR( 15 ) NOT NULL DEFAULT 'centro';"
            myCommand.ExecuteNonQuery()
            '*******************************************
            myCommand.Parameters.Clear()
            myCommand.CommandText = "ALTER TABLE `cobdpen` CHANGE `ccosto` `ccosto` VARCHAR( 15 ) NOT NULL "
            myCommand.ExecuteNonQuery()
            '********************
            myCommand.Parameters.Clear()
            myCommand.CommandText = "ALTER TABLE `ctas_x_pagar` CHANGE `ccosto` `ccosto` VARCHAR( 15 ) NOT NULL "
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("GENERAL===>" & ex.ToString)
        End Try
        '****** CONTABILIDAD *******************
        Try
            If FrmPrincipal.Contabilidad.Enabled = True Then
                myCommand.Parameters.Clear()
                myCommand.CommandText = "ALTER TABLE centrocostos CHANGE `centro` `centro` VARCHAR( 15 ) NOT NULL;"
                myCommand.ExecuteNonQuery()
                For i = 0 To 12
                    If i < 10 Then
                        per = "0" & i
                    Else
                        per = i
                    End If
                    myCommand.Parameters.Clear()
                    myCommand.CommandText = "ALTER TABLE `documentos" & per & "` CHANGE `centro` `centro` VARCHAR( 15 ) NOT NULL "
                    myCommand.ExecuteNonQuery()
                Next
                For i = 1 To 12
                    If i < 10 Then
                        per = "0" & i
                    Else
                        per = i
                    End If
                    myCommand.Parameters.Clear()
                    myCommand.CommandText = "ALTER TABLE `ot_doc" & per & "` CHANGE `ccosto` `ccosto` VARCHAR( 15 ) NOT NULL "
                    myCommand.ExecuteNonQuery()
                Next
            End If
        Catch ex As Exception
            MsgBox("CONTABILIDAD===>" & ex.ToString)
        End Try
        '***************** inventarios //////////////////////////////
        Try
            If FrmPrincipal.Inventarios.Enabled = True Then
                For i = 1 To 12
                    If i < 10 Then
                        per = "0" & i
                    Else
                        per = i
                    End If
                    myCommand.Parameters.Clear()
                    myCommand.CommandText = "ALTER TABLE `movimientos" & per & "` CHANGE `cc` `cc` VARCHAR( 15 ) NOT NULL "
                    myCommand.ExecuteNonQuery()
                Next
            End If
        Catch ex As Exception
            MsgBox("INVENTARIOS===>" & ex.ToString)
        End Try
        '****** FACTURACION****************************
        Try
            If FrmPrincipal.Facturacion.Enabled = True Then
                For i = 1 To 12
                    If i < 10 Then
                        per = "0" & i
                    Else
                        per = i
                    End If
                    myCommand.Parameters.Clear()
                    myCommand.CommandText = "ALTER TABLE `facturas" & per & "` CHANGE `cc` `cc` VARCHAR( 15 ) NOT NULL "
                    myCommand.ExecuteNonQuery()
                Next
                myCommand.Parameters.Clear()
                myCommand.CommandText = "ALTER TABLE `fapipen` CHANGE `ccosto` `ccosto` VARCHAR( 15 ) NOT NULL "
                myCommand.ExecuteNonQuery()
            End If
        Catch ex As Exception
            MsgBox("FACTURACION===>" & ex.ToString)
        End Try
        '***** cartera ******************
        Try
            If FrmPrincipal.Cartera.Enabled = True Then
                For i = 1 To 12
                    If i < 10 Then
                        per = "0" & i
                    Else
                        per = i
                    End If
                    myCommand.Parameters.Clear()
                    myCommand.CommandText = "ALTER TABLE `ot_cpc" & per & "` CHANGE `ccosto` `ccosto` VARCHAR( 15 ) NOT NULL "
                    myCommand.ExecuteNonQuery()
                Next
            End If
        Catch ex As Exception
            MsgBox("CARTERA===>" & ex.ToString)
        End Try
        '***** proveedores ******************
        Try
            If FrmPrincipal.Cartera.Enabled = True Then
                For i = 1 To 12
                    If i < 10 Then
                        per = "0" & i
                    Else
                        per = i
                    End If
                    myCommand.Parameters.Clear()
                    myCommand.CommandText = "ALTER TABLE `ot_cpp" & per & "` CHANGE `ccosto` `ccosto` VARCHAR( 15 ) NOT NULL "
                    myCommand.ExecuteNonQuery()
                    myCommand.Parameters.Clear()
                    myCommand.CommandText = "ALTER TABLE `fact_comp" & per & "` CHANGE `ctoc` `ctoc` VARCHAR( 15 ) NOT NULL "
                    myCommand.ExecuteNonQuery()
                Next
            End If
        Catch ex As Exception
            MsgBox("PROVEEDORES===>" & ex.ToString)
        End Try
    End Sub
    Public Sub TablaAnticipos(ByVal bd As String)
        Try ' ANTICIPOS DE CLIENTES
            myCommand.CommandText = "CREATE TABLE  IF NOT EXISTS " & bd & ".ant_de_clie (" _
                                  & "`per_doc` VARCHAR( 25 ) NOT NULL ," _
                                  & "`doc` VARCHAR( 15 ) NOT NULL ," _
                                  & "`per` VARCHAR( 7 ) NOT NULL ," _
                                  & "`fecha` DATE NOT NULL ," _
                                  & "`nitc` VARCHAR( 15 ) NOT NULL ," _
                                  & "`monto` DOUBLE NOT NULL ," _
                                  & "`causado` DOUBLE NOT NULL ," _
                                  & "`cta` VARCHAR( 15 ) NOT NULL ," _
                                  & "`user` VARCHAR( 30 ) NOT NULL ," _
                                  & "`fechacrea` datetime NOT NULL," _
                                  & " `concepto` VARCHAR( 600 ) NOT NULL," _
                                  & "PRIMARY KEY ( `per_doc` )" _
                                  & "); "
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            Exit Sub
        End Try

        Try ' ANTICIPOS A PROVEEDORES
            myCommand.CommandText = "CREATE TABLE  IF NOT EXISTS " & bd & ".ant_a_prov (" _
                                  & "`per_doc` VARCHAR( 25 ) NOT NULL ," _
                                  & "`doc` VARCHAR( 15 ) NOT NULL ," _
                                  & "`per` VARCHAR( 7 ) NOT NULL ," _
                                  & "`fecha` DATE NOT NULL ," _
                                  & "`nitc` VARCHAR( 15 ) NOT NULL ," _
                                  & "`monto` DOUBLE NOT NULL ," _
                                  & "`causado` DOUBLE NOT NULL ," _
                                  & "`cta` VARCHAR( 15 ) NOT NULL ," _
                                  & "`user` VARCHAR( 30 ) NOT NULL ," _
                                  & "`fechacrea` datetime NOT NULL," _
                                  & " `concepto` VARCHAR( 600 ) NOT NULL," _
                                  & "PRIMARY KEY ( `per_doc` )" _
                                  & "); "
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        Dim pr As String = ""
        Try
            For i = 1 To 12
                If i < 10 Then
                    pr = "0" & i
                Else
                    pr = i
                End If
                myCommand.Parameters.Clear()
                myCommand.CommandText = " ALTER TABLE  `ot_doc" & pr & "` ADD  `cod_contra` VARCHAR( 4 ) NOT NULL ; "
                myCommand.ExecuteNonQuery()
            Next

        Catch ex As Exception
        End Try
        Try
            For i = 1 To 12
                If i < 10 Then
                    pr = "0" & i
                Else
                    pr = i
                End If
                myCommand.Parameters.Clear()
                myCommand.CommandText = "ALTER TABLE fact_comp" & pr & " ADD `doc1` VARCHAR( 25 ) NOT NULL DEFAULT ' '," _
                & "ADD `doc2` VARCHAR( 25 ) NOT NULL DEFAULT ' '," _
                & "ADD `doc3` VARCHAR( 25 ) NOT NULL DEFAULT ' ';"
                myCommand.ExecuteNonQuery()
            Next
        Catch ex As Exception

        End Try
        Try
            For i = 1 To 12
                If i < 10 Then
                    pr = "0" & i
                Else
                    pr = i
                End If
                myCommand.Parameters.Clear()
                myCommand.CommandText = "ALTER TABLE ot_cpp" & pr & " ADD `doc_anti` VARCHAR( 25 ) NOT NULL DEFAULT ' ';"
                myCommand.ExecuteNonQuery()
            Next
        Catch ex As Exception

        End Try
        Try
            For i = 1 To 12
                If i < 10 Then
                    pr = "0" & i
                Else
                    pr = i
                End If
                myCommand.Parameters.Clear()
                myCommand.CommandText = "ALTER TABLE ot_cpc" & pr & " ADD `doc_anti` VARCHAR( 25 ) NOT NULL DEFAULT ' ';"
                myCommand.ExecuteNonQuery()
            Next
        Catch ex As Exception

        End Try
        Try
            For i = 1 To 12
                If i < 10 Then
                    pr = "0" & i
                Else
                    pr = i
                End If
                myCommand.Parameters.Clear()
                myCommand.CommandText = "ALTER TABLE facturas" & pr & " ADD `doc1` VARCHAR( 25 ) NOT NULL DEFAULT ' '," _
                & "ADD `doc2` VARCHAR( 25 ) NOT NULL DEFAULT ' '," _
                & "ADD `doc3` VARCHAR( 25 ) NOT NULL DEFAULT ' ';"
                myCommand.ExecuteNonQuery()
            Next
        Catch ex As Exception

        End Try
    End Sub
    Public Sub PasarAnticipos(ByVal nbd As String)
        Try
            Dim Sql As String = ""
            Sql = " INSERT INTO " & nbd & ".ant_de_clie SELECT * FROM " & bda & ".ant_de_clie WHERE (monto-causado)>0 "
            Insertar(Sql)
            'Dim tabla As New DataTable
            'tabla.Clear()
            'myCommand.CommandText = "SELECT * FROM " & bda & ".ant_de_clie WHERE (monto-causado)>0;" 'tiene saldo pendiente
            'myAdapter.SelectCommand = myCommand
            'myAdapter.Fill(tabla)
            'For i = 0 To tabla.Rows.Count - 1
            '    'Sql = "INSERT INTO " & nbd & ".ant_de_clie (per_doc,doc,per,fecha,nitc,monto,causado,cta,user,fechacrea,concepto) " _
            '    '    & "Values('" & tabla.Rows(i).Item("per_doc") & "','" & tabla.Rows(i).Item("doc") & "','" & tabla.Rows(i).Item("per") & "'," _
            '    '    & "'" & tabla.Rows(i).Item("fecha") & "','" & tabla.Rows(i).Item("nitc") & "','" & tabla.Rows(i).Item("monto") & "'," _
            '    '    & "'" & tabla.Rows(i).Item("causado") & "','" & tabla.Rows(i).Item("cta") & "','" & tabla.Rows(i).Item("user") & "','" & tabla.Rows(i).Item("fechacrea") & "','" & tabla.Rows(i).Item("concepto") & "');"
            '    Insertar(Sql)
            'Next
        Catch ex As Exception
            MsgBox("Error pasando los anticipos de clientes " & ex.ToString)
        End Try

        Try
            Dim Sql As String = ""
            Sql = " INSERT INTO " & nbd & ".ant_a_prov SELECT * FROM " & bda & ".ant_a_prov WHERE (monto-causado)>0"
            Insertar(Sql)

            'Dim tabla As New DataTable
            'tabla.Clear()
            'myCommand.CommandText = "SELECT * FROM " & bda & ".ant_a_prov WHERE (monto-causado)>0;" 'tiene saldo pendiente
            'myAdapter.SelectCommand = myCommand
            'myAdapter.Fill(tabla)
            'For i = 0 To tabla.Rows.Count - 1
            '    Sql = "INSERT INTO " & nbd & ".ant_a_prov (per_doc,doc,per,fecha,nitc,monto,causado,cta,user,fechacrea,concepto) " _
            '        & "Values('" & tabla.Rows(i).Item("per_doc") & "','" & tabla.Rows(i).Item("doc") & "','" & tabla.Rows(i).Item("per") & "'," _
            '        & "'" & tabla.Rows(i).Item("fecha") & "','" & tabla.Rows(i).Item("nitc") & "','" & tabla.Rows(i).Item("monto") & "'," _
            '        & "'" & tabla.Rows(i).Item("causado") & "','" & tabla.Rows(i).Item("cta") & "','" & tabla.Rows(i).Item("user") & "','" & tabla.Rows(i).Item("fechacrea") & "','" & tabla.Rows(i).Item("concepto") & "');"
            '    Insertar(Sql)
            'Next
        Catch ex As Exception
            MsgBox("Error pasando los anticipos de proveedores " & ex.ToString)
        End Try

    End Sub

    Public Sub CrearVista()
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "CREATE VIEW vista_canti AS select *,'0' AS ctotal,lpad(month(now()),2,'0') AS mes from articulos where nivel <> 'Articulos' union select a.*,sum(c.cant1 + c.cant2 + c.cant3 + c.cant4 + c.cant5 + c.cant6 + c.cant7) AS ctotal,lpad(month(now()),2,'0') AS mes from articulos a left join con_inv c on a.codart = c.codart where c.periodo = lpad(month(now()),2,'0') group by a.codart;"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub ord_pagos(ByVal bd As String)
        Try ' ORDENES DE PAGOS
            myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".`ord_pagos` ( " _
          & " `doc` varchar(30) NOT NULL COMMENT 'documento'," _
          & " `per` varchar(7) NOT NULL COMMENT 'periodo', " _
          & " `num` bigint(20) NOT NULL COMMENT 'numero de documento'," _
          & " `fecha` date NOT NULL COMMENT 'fecha de elaboracion'," _
          & " `con_num` varchar(20) NOT NULL COMMENT 'numero de contrato'," _
          & " `con_ben` varchar(15) NOT NULL COMMENT 'nit tercero'," _
          & " `nomnit` varchar(200) NOT NULL COMMENT 'nombre del tercero'," _
          & " `con_objeto` text NOT NULL COMMENT 'objeto del contrato'," _
          & " `con_valor` double NOT NULL COMMENT 'valor del contrato'," _
          & " `con_plazo` varchar(5) NOT NULL COMMENT 'plazo del contrato'," _
          & " `sop_cont` varchar(30) NOT NULL COMMENT 'soporte / documento de egreso'," _
          & " `cta_rubro` text NOT NULL COMMENT 'cta de rubro'," _
          & " `v_bruto` double NOT NULL COMMENT 'valor bruto'," _
          & " `v_neto` double NOT NULL COMMENT 'valor neto a pagar'," _
          & " `v_iva` double NOT NULL COMMENT 'valor del iva del contrato'," _
          & " `estado` varchar(2) NOT NULL COMMENT 'Estado de la orden'," _
          & " `user` varchar(20) NOT NULL COMMENT 'ultimo usuario que modifico'," _
          & " `ult_up` datetime NOT NULL COMMENT 'fecha de la ultima modificacion'," _
          & "  `doccxp` VARCHAR( 15 ) NOT NULL COMMENT  'doc cuentas por pagar'," _
          & " `resolucion` VARCHAR( 40 ) NOT NULL COMMENT  'resolucion'," _
          & " PRIMARY KEY  (`doc`)" _
          & " ) ;"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception

        End Try

        Try ' DETALLES ORDENES 
            myCommand.CommandText = " CREATE TABLE IF NOT EXISTS " & bd & ".`deta_ord` ( " _
          & "`doc` varchar(30) NOT NULL COMMENT 'orden de compra'," _
          & "`cta` varchar(18) NOT NULL COMMENT 'cta contable'," _
          & "`concep` text NOT NULL COMMENT 'concepto del movimiento'," _
          & "`db` double NOT NULL COMMENT 'valor debito'," _
          & "`cr` double NOT NULL COMMENT 'valor credito'," _
          & "`porc` double NOT NULL COMMENT 'porcentaje'," _
          & "`tipo` varchar(2) NOT NULL COMMENT 'tipo de movimiento' " _
          & ") ;"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Try
            myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bd & ".`ParOrdenes` (" _
          & " `num` INT NOT NULL ," _
         & " `titulo1` VARCHAR( 60 ) NOT NULL , " _
         & " `msj1` VARCHAR( 60 ) NOT NULL , " _
         & " `firma1` VARCHAR( 100 ) NOT NULL , " _
         & " `pie1` VARCHAR( 60 ) NOT NULL , " _
         & " `titulo2` VARCHAR( 60 ) NOT NULL , " _
         & " `msj2` VARCHAR( 60 ) NOT NULL , " _
         & " `firma2` VARCHAR( 100 ) NOT NULL , " _
         & " `pie2` VARCHAR( 60 ) NOT NULL , " _
         & " `titulo3` VARCHAR( 60 ) NOT NULL ," _
         & " `msj3` VARCHAR( 60 ) NOT NULL , " _
         & " `firma3` VARCHAR( 100 ) NOT NULL , " _
         & " `pie3` VARCHAR( 60 ) NOT NULL , " _
         & " `titulo4` VARCHAR( 60 ) NOT NULL , " _
         & " `msj4` VARCHAR( 60 ) NOT NULL , " _
         & " `firma4` VARCHAR( 100 ) NOT NULL , " _
         & " `pie4` VARCHAR( 60 ) NOT NULL , " _
         & " `titulo5` VARCHAR( 60 ) NOT NULL , " _
         & " `msj5` VARCHAR( 60 ) NOT NULL , " _
         & " `firma5` VARCHAR( 100 ) NOT NULL , " _
         & " `pie5` VARCHAR( 60 ) NOT NULL, " _
         & " `forden` CHAR( 1 ) NOT NULL, " _
         & " `fce` CHAR( 1 ) NOT NULL, " _
         & " `nord` CHAR( 1 ) NOT NULL DEFAULT  'M' " _
        & " ) ENGINE = INNODB; "
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Try
            myCommand.CommandText = " ALTER TABLE  `parordenes` ADD  `nord` CHAR( 1 ) NOT NULL DEFAULT  'M'; "
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Try
            myCommand.CommandText = " CREATE TABLE  IF NOT EXISTS " & bd & ".`parreso` (" _
             & " `titulo` TEXT NOT NULL , " _
             & " `municipio` VARCHAR( 200 ) NOT NULL , " _
             & " `firma` VARCHAR( 200 ) NOT NULL , " _
             & " `pie` VARCHAR( 200 ) NOT NULL " _
            & " ) ENGINE = INNODB; "
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Try
            myCommand.CommandText = "ALTER TABLE  `parordenes` ADD  `forden` CHAR( 1 ) NOT NULL ," _
            & " ADD  `fce` CHAR( 1 ) NOT NULL ;"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Try
            myCommand.CommandText = "ALTER TABLE  presupuesto" & Strings.Right(PerActual, 4) & ".`pagos` ADD  `pag_sae` VARCHAR( 2 ) NOT NULL DEFAULT  " _
                                & " 'NO' COMMENT  'doc pagado en sae';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        Try
            myCommand.CommandText = "ALTER TABLE  presupuesto" & Strings.Right(PerActual, 4) & ".`movgastos` ADD  `mov_vsae` DOUBLE NOT NULL COMMENT  'valor pagado sae';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Try
            myCommand.CommandText = " CREATE TABLE  IF NOT EXISTS " & bd & ".`parrecaudo` (" _
         & "`ci` VARCHAR( 4 ) NOT NULL , " _
         & "`rc` VARCHAR( 4 ) NOT NULL " _
         & " ) ENGINE = INNODB; "
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try


        Try
            myCommand.CommandText = "CREATE TABLE  IF NOT EXISTS " & bd & ".`otdoc_pres` (" _
         & "`num` DOUBLE NOT NULL AUTO_INCREMENT PRIMARY KEY , " _
         & " `rb` VARCHAR( 500 ) NOT NULL," _
         & "`rb_cod1` VARCHAR( 50 ) NOT NULL , " _
         & "`rb_cod2` VARCHAR( 50 ) NOT NULL , " _
         & "`nitc` VARCHAR( 15 ) NOT NULL , " _
         & "`nombre` VARCHAR( 200 ) NOT NULL , " _
         & "`fecha` DATE NOT NULL , " _
         & "`doc_ci` VARCHAR( 15 ) NOT NULL , " _
         & " `num_ci` BIGINT( 20 ) NOT NULL, " _
         & "`doc_rc` VARCHAR( 15 ) NOT NULL , " _
         & "`num_rc` BIGINT( 20 ) NOT NULL, " _
         & "`concepto` VARCHAR( 100 ) NOT NULL , " _
         & "`valor` DOUBLE NOT NULL, " _
         & " `tipoing` CHAR( 1 ) NOT NULL DEFAULT  '1' COMMENT  '1: ing causac 2:ing normal' " _
        & ") ENGINE = INNODB; "
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        Try
            myCommand.CommandText = "ALTER TABLE  `otdoc_pres` ADD  `tipoing` CHAR( 1 ) NOT NULL DEFAULT  '1' COMMENT  '1: ing causac 2:ing normal';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Try
            myCommand.CommandText = "CREATE TABLE  IF NOT EXISTS " & bd & ".`conciliacion` (" _
             & " `num` BIGINT( 20 ) NOT NULL , " _
             & " `per` VARCHAR( 10 ) NOT NULL , " _
             & " `dia` VARCHAR( 2 ) NOT NULL , " _
             & " `ctabanco` VARCHAR( 15 ) NOT NULL , " _
             & " `doccon` VARCHAR( 15 ) NOT NULL , " _
             & " `docotros` VARCHAR( 15 ) NOT NULL , " _
             & " `doccuadre` VARCHAR( 15 ) NOT NULL , " _
             & " `fini` DATE NOT NULL , " _
             & " `ffin` DATE NOT NULL , " _
             & " `salaj` DOUBLE NOT NULL , " _
             & " `salbanco` DOUBLE NOT NULL , " _
             & "`sallibro` DOUBLE NOT NULL ," _
            & " `elaborado` VARCHAR( 20 ) NOT NULL," _
            & " PRIMARY KEY (  `num` ) , " _
            & " INDEX (  `doccon` ,  `docotros` ,  `doccuadre` ) " _
            & " ) ENGINE = INNODB; "
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Try
            myCommand.CommandText = " CREATE TABLE IF NOT EXISTS " & bd & ".`datos_nomina` (" _
          & " `conse_nomina` varchar(20) NOT NULL, " _
          & " `nombre_nomina` varchar(200) default NULL, " _
          & " `tipodoc` varchar(5) default NULL, " _
          & " `periodo` varchar(20) default NULL, " _
          & " `inicio` varchar(10) default NULL, " _
          & " `fin` varchar(10) default NULL, " _
          & " PRIMARY KEY  (`conse_nomina`) " _
            & " myCommand.ExecuteNonQuery()) ;"
        Catch ex As Exception
        End Try

    End Sub

    Public Sub bancos(ByVal bd As String)

        Try ' DETALLES ORDENES 
            myCommand.CommandText = " CREATE TABLE `bancos` ( " _
              & "`cod_ban` varchar(10) NOT NULL," _
              & "`codigo` varchar(15) NOT NULL," _
              & "`banco` varchar(200) NOT NULL," _
              & "`num_cta` varchar(30) NOT NULL," _
              & "`nombre` varchar(200) NOT NULL," _
              & "`nit` varchar(15) NOT NULL," _
              & "PRIMARY KEY  (`cod_ban`)," _
              & "UNIQUE KEY `codigo` (`codigo`)" _
              & ");"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        
    End Sub
    Public Sub Auditoria(ByVal bd As String)


        Try ' CREAR TABLA INCONSISTENCIAS
            myCommand.Parameters.Clear()
            myCommand.CommandText = " CREATE TABLE  IF NOT EXISTS " & bd & ".auditoria ( " _
            & " `formulario` TEXT  NOT NULL ," _
            & " `usuario` VARCHAR( 30 ) NOT NULL , " _
            & " `periodo` VARCHAR( 10 ) NOT NULL , " _
            & " `dia` VARCHAR( 2 ) NOT NULL , " _
            & " `hora` TIME NOT NULL , " _
            & " `tip_cuenta` VARCHAR( 30 ) NOT NULL ," _
            & " `cuenta_err` VARCHAR( 15 ) NOT NULL , " _
            & " `doc_alt` VARCHAR( 20 ) NOT NULL COMMENT 'documento alterado', " _
             & " `fec_aud` DATE  NOT NULL  " _
            & " ) ENGINE = MYISAM ; "
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try


        Try ' CREAR TABLA AUDITORIA FACTURACION
            myCommand.Parameters.Clear()
            myCommand.CommandText = " CREATE TABLE  IF NOT EXISTS " & bd & ".audi_parfac (" _
             & " `tip_puc` VARCHAR( 15 ) NOT NULL DEFAULT  'comercial', " _
             & " `c1_caj` VARCHAR( 15 ) NOT NULL , " _
             & " `c2_ban` VARCHAR( 15 ) NOT NULL , " _
             & " `c3_cxc` VARCHAR( 15 ) NOT NULL , " _
             & " `c4_inv` VARCHAR( 15 ) NOT NULL , " _
             & " `c5_ven` VARCHAR( 15 ) NOT NULL , " _
             & " `c6_cven` VARCHAR( 15 ) NOT NULL , " _
             & " `c7_ivap` VARCHAR( 15 ) NOT NULL , " _
             & "`c8_ivad` VARCHAR( 15 ) NOT NULL , " _
             & " `c9_des` VARCHAR( 15 ) NOT NULL , " _
             & "  `c10_rtf` VARCHAR( 15 ) NOT NULL , " _
             & " `c11_rtic` VARCHAR( 15 ) NOT NULL , " _
             & " `c12_rtiv` VARCHAR( 15 ) NOT NULL " _
             & ") ENGINE = MYISAM ; "
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Try ' CREAR TABLA AUDITORIA COMPRAS
            myCommand.Parameters.Clear()
            myCommand.CommandText = "CREATE TABLE  IF NOT EXISTS " & bd & ".audi_parcom (" _
         & " `tip_puc` VARCHAR( 15 ) NOT NULL DEFAULT  'comercial', " _
         & " `c1_caj` VARCHAR( 15 ) NOT NULL , " _
         & " `c2_ban` VARCHAR( 15 ) NOT NULL , " _
         & " `c3_cxp` VARCHAR( 15 ) NOT NULL , " _
          & " `c4_gas` VARCHAR( 15 ) NOT NULL , " _
         & " `c5_com` VARCHAR( 15 ) NOT NULL , " _
         & " `c6_des` VARCHAR( 15 ) NOT NULL, " _
         & "  `c7_inv` VARCHAR( 15 ) NOT NULL ," _
          & " `c8_ivap` VARCHAR( 15 ) NOT NULL , " _
         & " `c9_ivad` VARCHAR( 15 ) NOT NULL , " _
         & " `c10_rtf` VARCHAR( 15 ) NOT NULL, " _
         & "  `c11_fle` VARCHAR( 15 ) NOT NULL ," _
          & " `c12_seg` VARCHAR( 15 ) NOT NULL , " _
         & " `c13_pc` VARCHAR( 15 ) NOT NULL , " _
         & " `c14_pd` VARCHAR( 15 ) NOT NULL " _
         & " ) ENGINE = MYISAM ; "
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = " CREATE TABLE  IF NOT EXISTS " & bd & ".aud_otdoc( " _
            & " `tip_puc` VARCHAR( 15 ) NOT NULL DEFAULT  'comercial', " _
            & "`c1_caj` VARCHAR( 15 ) NOT NULL ,  " _
            & " `c2_ban` VARCHAR( 15 ) NOT NULL ,  " _
            & " `c3_cxc` VARCHAR( 15 ) NOT NULL ,  " _
            & " `c4_cxp` VARCHAR( 15 ) NOT NULL  " _
            & " ) ENGINE = MYISAM ; "
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub Auditoria_movimientos()

        ' ......... TABLA MOVIMIENTO USUARIOS................
        Dim bd As String = ""
        Try
            bd = "user" & FrmPrincipal.lbcompania.Text.ToLower & Strings.Right(PerActual, 4)
            'CREAR BASE DE DATOS 
            myCommand.CommandText = "CREATE DATABASE IF NOT EXISTS " & bd & "; "
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Try
            Dim pr As String = ""
            For i = 1 To 12
                If i < 10 Then
                    pr = "0" & i
                Else
                    pr = i
                End If
                myCommand.CommandText = " CREATE TABLE IF NOT EXISTS " & bd & ".mov" & pr & " (" _
                 & " `usuario` VARCHAR( 30 ) NOT NULL , " _
                 & " `fecha` DATE NOT NULL , " _
                 & " `hora` TIME NOT NULL , " _
                 & "  `form` TEXT NOT NULL ," _
                 & " `tipmov` TEXT NOT NULL, " _
                 & " `campos` TEXT NOT NULL, " _
                 & " `anterior` TEXT NOT NULL, " _
                 & " `nuevo` TEXT NOT NULL, " _
                 & " `per` VARCHAR( 2 ) NOT NULL  " _
                 & " ) ENGINE = MYISAM ; "
                myCommand.ExecuteNonQuery()
            Next
        Catch ex As Exception
        End Try

        'Try
        '    myCommand.CommandText = " CREATE TABLE IF NOT EXISTS " & bd & ".`todosmov` (" _
        '  & " `doc` TEXT NOT NULL ," _
        '  & " `campo` TEXT NOT NULL , " _
        '  & " `anterior` TEXT NOT NULL , " _
        '  & " `nuevo` TEXT NOT NULL , " _
        '  & " `fecha` DATE NOT NULL" _
        '  & " ) ENGINE = INNODB; "
        '    myCommand.ExecuteNonQuery()
        'Catch ex As Exception
        'End Try
    End Sub
    Public Sub ord_cxp(ByVal bd As String)
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = " ALTER TABLE  " & bd & ".`ord_pagos` ADD  `doccxp` VARCHAR( 15 ) NOT NULL COMMENT  'doc cuentas por pagar';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "ALTER TABLE  " & bd & ".`ord_pagos` ADD  `resolucion` VARCHAR( 40 ) NOT NULL COMMENT  'resolucion';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "  ALTER TABLE  " & bd & ".`ctas_x_pagar` CHANGE  `pagare`  `pagare` VARCHAR( 30 ) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = " ALTER TABLE  " & bd & ".`ctas_x_pagar` CHANGE  `descrip`  `descrip` TEXT CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        Try
            ' CAMBIAR LONGITUD CAMPO CCOSTO PARA ORDENES DE PAGO
            myCommand.Parameters.Clear()
            myCommand.CommandText = "  ALTER TABLE  " & bd & ".`ctas_x_pagar` CHANGE  `ccosto`  `ccosto` TEXT CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL;"
            myCommand.ExecuteNonQuery()

            myCommand.Parameters.Clear()
            myCommand.CommandText = "  ALTER TABLE  " & bd & ".`ctas_x_pagar` CHANGE  `rcpos`  `rcpos` TEXT CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL;"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
    End Sub


End Module

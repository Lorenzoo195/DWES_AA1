Actividad de Aprendizaje 1 - Desarrollo Web en Entorno Servidor

**«Alumno»**

Nombre, Apellido 1, Apellido 2 

**Actividad de Aprendizaje 1** 

**1ª Evaluación** 

**Curso 2026-2027**

**Desarrollo Web en Entorno Servidor**

**FUNDACIÓN   SAN VALERO**

**SEAS, Centro de Formación Abierta**

` `**ZARAGOZA** 



**Propuesta de trabajo** 

Esta Actividad de Aprendizaje consiste en desarrollar una API REST que gestione información mediante una base de datos y se ejecute en un entorno local utilizando contenedores Docker.

**Hay libertad para escoger el propósito de la aplicación** (ej. catálogo de productos, recetas, lugares…), sin necesidad de aprobación previa del profesor. No obstante, el alumnado deberá asegurarse de que la temática seleccionada permite cumplir todos los requisitos de la actividad. En caso de duda, se recomienda consultar previamente con el profesor, ya que una elección inadecuada no justificará el incumplimiento de dichos requisitos. 

Junto con el desarrollo de la aplicación, se deberá entregar una documentación que incluya el nombre de la aplicación, su propósito, funcionalidades e instrucciones para su ejecución.  

Las tareas por desarrollar se componen de dos bloques. El primer bloque se compone de **funcionalidades obligatorias** que deben ser implementadas. El segundo bloque son **funcionalidades extra** que servirán para subir nota sobre el aprobado. **Si se te ocurren otras funcionalidades extra interesantes** para la aplicación, habla con el profesor para evaluar la posibilidad de incorporarlas en tu evaluación.

Tras la entrega del trabajo, se realizará una **prueba de autoría que debe superarse,** evaluando el esfuerzo y conocimientos adquiridos en el proyecto, para dar por válido el trabajo.

**Modalidad de trabajo**

La actividad podrá realizarse individualmente o en parejas, con preferencia por el trabajo en equipo. En caso de realizarse en pareja, ambos integrantes deberán participar activamente en el desarrollo y demostrar el conocimiento de la solución implementada. La evaluación será individual.


### <a name="_heading=h.ovtanuqy3tbl"></a>**Funcionalidades obligatorias**
- (1 p) Diseña una API RESTful que implemente operaciones CRUD sobre los recursos de la aplicación, utilizando correctamente los métodos HTTP, las rutas y los códigos de estado correspondientes, incluyendo el tratamiento adecuado de errores y excepciones. 
- (1 p) El modelo de datos deberá contener al menos cinco entidades con relaciones entre ellas, con propiedades de distintos tipos de datos (string, int, decimal, bool, DateTime) e implementando validaciones de entrada.
- (1 p) Implementa endpoints que permitan consultar recursos relacionados y realizar búsquedas, filtros y ordenaciones. Se deberá permitir filtrar y ordenar por al menos dos propiedades distintas del identificador.
- (1 p) Conteneriza la aplicación (API conectada a una base de datos) mediante Docker, configurando los siguientes puertos en el equipo anfitrión:
  - API: las cuatro últimas cifras de tu usuario de San Valero (ej. a24569@svalero.com → puerto 4569).
  - Base de datos: las mismas cuatro cifras en orden inverso (ej. a24569@svalero.com → puerto 9654).
- (1 p) Publica la imagen de la API en un registro de contenedores y descárgala posteriormente para ejecutar la aplicación. Orquesta la API y la base de datos mediante Docker Compose, configurando correctamente la comunicación entre ambos servicios.
### **Funcionalidades extra**
- (1 p) Utiliza Git y la metodología Gitflow durante todo el desarrollo de la aplicación.
- <a name="_heading=h.9njo8pmd6b4o"></a>(1 p) Crea una colección de Postman con peticiones HTTP para documentar y probar los endpoints de la API. 
- (1 p) Implementa al menos dos endpoints que proporcionen información estadística o agregada, calculada a partir de los datos de la aplicación (ej. recuentos agrupados, promedios, máximos, mínimos o totales).
- (1 p) Desarrolla una aplicación cliente contenerizada que consuma la API. Se permite cualquier tecnología, web o consola, y reutilizar proyectos de otras asignaturas. 
- (1 p) Nivel de madurez técnica del proyecto y uso crítico de la IA. Se valorará especialmente la calidad y organización del código, la arquitectura del proyecto, la separación de responsabilidades, el tratamiento de errores y la documentación técnica. Se tendrá en cuenta el uso crítico y reflexivo de herramientas de IA, cuando se utilicen, así como la capacidad para comprender y justificar las soluciones implementadas.
### <a name="_heading=h.1mmtdx73642o"></a>**Entrega**
La actividad se entregará en un único archivo ZIP que deberá contener:

- Código fuente completo, incluyendo los archivos necesarios para configurar y ejecutar la aplicación.
- Documentación en formato PDF o Markdown, con el nombre de la aplicación, su propósito, funcionalidades e instrucciones de ejecución.
- Evidencias necesarias para comprobar los requisitos, organizadas libremente dentro del ZIP.

No se incluirán archivos ni carpetas generados automáticamente durante la compilación o ejecución (por ejemplo, bin, obj).

Además del archivo ZIP, en caso de utilizar un repositorio Git, se deberá adjuntar su URL como recurso de la entrega en Classroom, asegurando que el profesor tenga acceso a su contenido.

<a name="_heading=h.1fb30jomy3wl"></a>En caso de realizar la actividad en pareja, se entregará un único archivo ZIP por equipo, identificando a ambos integrantes en la documentación y en un comentario privado de la entrega en Classroom.

<a name="_heading=h.w7hxlliql3fa"></a>Para que la entrega se considere válida, todos los alumnos deberán pulsar «Entregar» en Classroom, independientemente de si realizan la actividad individualmente o en pareja.
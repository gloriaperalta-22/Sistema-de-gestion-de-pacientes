# Proyecto Sistema de Gestión de Pacientes

## Integrantes
* **Aldo Gabriel Frias Deveaux** - Matrícula: 2026-0496
* **Jauden Jose Ubiera Pérez** - Matrícula: 2026-0129
* **Alan Mena Montero** - Matrícula: 2026-0818
* **Gloria Estefani Peralta Solano** - Matrícula: 2026-0685

---

## Descripción Breve
Aplicación de escritorio desarrollada en C# con Windows Forms y Programación Orientada a Objetos (POO) para la administración de pacientes en un centro de salud. El sistema permite gestionar expedientes médicos ejecutando las cuatro operaciones fundamentales del CRUD (Crear, Leer, Actualizar, Eliminar). Toda la información se almacena en memoria durante la ejecución mediante listas dinámicas genéricas (`List<Paciente>`), organizando la lógica de negocio en clases independientes y desacopladas de la interfaz gráfica.

---

## Datos de Entrada
Información capturada a través de los controles de la interfaz gráfica (`TextBox`, `ComboBox`, `DateTimePicker`):
* **Cédula o ID (`txt_cedula`):** Identificador único del paciente en formato texto.
* **Nombre Completo (`txt_Nombre`):** Nombre y apellidos del paciente.
* **Edad (`txt_Edad`):** Valor numérico entero.
* **Diagnóstico (`txt_Diasnotico`):** Descripción del cuadro médico del paciente.
* **Sexo (`combo_Sexo`):** Valor seleccionado del enumerador `Sexo` (`Masculino`, `Femenino`).
* **Estado del Paciente (`combo_Estado`):** Valor seleccionado del enumerador `Estado` (`Emergencia`, `Interno`, `Dado de alta`).
* **Fecha de Ingreso (`dtp_FechaIngreso`):** Fecha y hora registradas desde el control `DateTimePicker`.
* **Criterio de Búsqueda (`txt_Buscar`):** Término para filtrar la lista por ID o Nombre.

---

## Datos que Procesa
Procesos y reglas de negocio aplicados en la capa lógica (`GestorPacientes.cs`) y validaciones de interfaz:
* **Validación de Entradas:** Verificación de campos obligatorios en el formulario y conversión numérica mediante `int.TryParse` para prevenir caídas ante texto alfanumérico.
* **Control de Duplicados:** Verificación de existencia de Cédula/ID antes de registrar un nuevo elemento en la lista `List<Paciente>`.
* **Manejo de Excepciones:** Control de errores en tiempo de ejecución utilizando bloques `try-catch` y la excepción personalizada `PacienteNoEncontradoException`.
* **Gestión de Lista Dinámica (`List<T>`):**
  * **Alta:** Inserción de nuevos objetos `Paciente`.
  * **Consulta/Filtrado:** Búsqueda dinámica en la lista comparando coincidencia por ID o Nombre.
  * **Modificación:** Búsqueda por ID y actualización de propiedades.
  * **Baja:** Eliminación del objeto localizado en la lista tras recibir la confirmación.

---

## Datos de Salida
Resultados proyectados hacia el usuario final:
* **Tabla de Resultados (`DataGridView` - `data_Lista`):** Muestra el listado dinámico de pacientes con columnas para ID, Nombre, Diagnóstico, Edad, Sexo, Estado y Fecha de Ingreso.
* **Carga en Formulario:** Retorno automático de atributos a los campos editables tras hacer clic en una fila de la tabla (evento `CellClick`).
* **Ventanas de Diálogo (`MessageBox`):**
  * Alertas informativas para confirmar operaciones exitosas.
  * Mensajes de advertencia e íconos de error contextuales ante datos inválidos o fallos.
  * Diálogos de confirmación (`MessageBoxButtons.YesNo`) antes de eliminar registros.

---

## Vista Previa

### 1. Interfaz Principal del Sistema
<img width="1448" height="788" alt="1 1 1" src="https://github.com/user-attachments/assets/0d883048-30a9-4924-bf1c-c94c6341bea7" />

### 2. Módulo de Registro (Crear) y Validaciones
<img width="1470" height="791" alt="1 1" src="https://github.com/user-attachments/assets/9b642716-a17a-4beb-aea0-bcb0e8677198" />

<img width="1452" height="788" alt="1 2" src="https://github.com/user-attachments/assets/b322b02d-eb06-48c3-af9d-a5e70d4e69fd" />

<img width="1140" height="689" alt="Captura de pantalla 2026-08-12 223959 (1)" src="https://github.com/user-attachments/assets/e1480e84-9fd2-452a-bbdb-8fb240cb7734" />

<img width="1139" height="681" alt="Captura de pantalla 2026-08-12 224045 (1)" src="https://github.com/user-attachments/assets/212f8c76-bd0c-4ca9-999d-bccfcbbbac7b" />



### 3. Módulo de Consulta e Interfaz
<img width="1463" height="802" alt="2 1" src="https://github.com/user-attachments/assets/2573a62a-d97d-440b-afbf-e61f8e2f1477" />

<img width="1452" height="781" alt="2 2" src="https://github.com/user-attachments/assets/7f5dfb1e-bbd2-43ca-931f-965c035b22f0" />

### 4. Módulo de Actualización (Modificar)
<img width="1442" height="788" alt="3 1" src="https://github.com/user-attachments/assets/0ea4bc3f-324b-4b34-b189-fdc65cb61524" />

<img width="1445" height="783" alt="3 2" src="https://github.com/user-attachments/assets/8c16be0f-4e91-4271-aa2d-49e1c496ceba" />

### 5. Módulo de Búsqueda y Eliminación (Buscar / Eliminar)
<img width="1430" height="765" alt="4 1" src="https://github.com/user-attachments/assets/5697c650-9732-4388-936f-ec7ed3a776a6" />

<img width="1438" height="777" alt="4 2" src="https://github.com/user-attachments/assets/581c6319-32e1-4bbc-8346-316b70f6b605" />

<img width="1457" height="791" alt="4 4 1" src="https://github.com/user-attachments/assets/aa5b0a3c-8a57-49b1-af50-61f39bbfab5d" />

<img width="1452" height="782" alt="4 4 2" src="https://github.com/user-attachments/assets/edb5ed0a-c49d-4c32-887b-8b5a7df77707" />

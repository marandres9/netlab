# LabNet2022
Repo para el lab .NET - Mayo 2022

El programa muestra un menú donde el usuario puede seleccionar opciones.

La clase Logic provee métodos para procesar la entrada del usuario y para realizar las operaciones de división y raiz cuadrada. Dichos métodos pueden lanzar excepciones, las cuales son capturadas por la clase Presentacion, encargada de manejar la consola. Dicha clase da aviso al usuario y lo devuelve al menú principal.

La clase Logic lanza excepciones si el usuario:
- ingresa datos invalidos para las operaciones, (por ej. una letra).
- intenta divir por 0.
- llama a uno de sus métodos que solo lanza una excepción simple.
- intenta sacar la cuadrada de un número negativo.

Además, se implemetó un método de extensión de la clase Double, que sirve para verificar si el número ingresado es negativo.
Tambien se incluye un proyecto de testing donde se prueban los métodos de la clase Logic.

# LabNet2022
Repo para el lab .NET - Mayo 2022

El programa muestra un menú donde el usuario puede seleccionar opciones de una calculadora. Una vez seleccionada la opción, se le pide ingresar los datos necesarios para la operación.

La clase Calculator provee métodos para procesar la entrada del usuario y para realizar las operaciones. Dichos métodos pueden lanzar excepciones, las cuales son capturadas por la clase CalculatorConsoleApp, encargada de manejar la consola. Dicha clase da aviso al usuario y lo devuelve al menú principal.

La clase Calculator lanza excepciones si el usuario:
- ingresa datos invalidos para las operaciones, (por ej. una letra).
- intenta divir por 0.
- intenta sacar la cuadrada de un número negativo.

Tambien se incluye un proyecto de testing donde se prueban los métodos de la clase Calculator.

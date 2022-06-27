from datetime import date
from datetime import datetime


error = True
listcod = ["abcdef#a$ghijl", "klmnop#k$tuvwx"]
edad = 1


def validar(codigo):
    errores = 0
    global error
    if len(codigo) == 14:
        if not codigo[6] == "#":
            print("ERROR: El caracter en la posición 7 debe ser #")
            errores += 1
        if not codigo[0] == codigo[7]:
            print("ERROR: El caracter en la primera y octava posición deben ser iguales")
            errores += 1
    else:
        print("ERROR: El código debe ser de 14 caracteres")
        errores += 1
    if any(char.isdigit() for char in codigo):
        print("ERROR: El código NO debe contener números")
        errores += 1
    if "$" not in codigo:
        print("ERROR: El código debe contener el caracter $")
        errores += 1
    if codigo.count('p') > 4:
        print("ERROR: El código NO debe contener más de 4 veces la letra 'p'")
        errores += 1
    if errores != 0:
        print("Revisa el código, hay ", errores, " errores")
        error = True
    else:
        error = False


def validar2(codigo):
    global error
    global listcod
    for cod in listcod:
        if cod == codigo:
            print("ERROR: El código ya está registrado en el sistema")
            error = True
        else:
            error = False


def validar3():
    global error
    global edad
    fecha = input("Ingrese la fecha de nacimiento en formato AAAA/MM/DD: ")
    fechaNac = datetime.strptime(fecha, "%Y/%m/%d")
    fechaActual = date.today()
    edad = fechaActual.year - fechaNac.year - ((fechaActual.month, fechaActual.day) < (fechaNac.month, fechaNac.day))
    if edad < 12:
        print("ERROR: Este juego es para mayores de 12 años")
        error = True


def getnick():
    nick = input("Ingrese un nickname (o alias de jugador): ")
    if len(nick) >= 4 and len(nick) <= 6 and " " not in nick:
        return nick
    else:
        print("ERROR: El nick debe estar entre 4 a 6 caracteres y no contener espacios")
        getnick()


def getdecision():
    decision = input("Ya has jugado el juego ADSO I? (Si-No): ")
    if decision == "si" or decision == "Si" or decision == "sI" or decision == "SI":
        return True
    elif decision == "no" or decision == "No" or decision == "nO" or decision == "NO":
        return False
    else:
        print("ERROR: Debe ingresar si o no")
        getdecision()


def getnivel():
    nivel = int(input("Hasta que nivel llegaste? (1-100): "))
    if nivel >= 1 and nivel <= 100:
        return nivel
    else:
        print("ERROR: Nivel no existente")
        getnivel()


def asignarnivel(decision, nivel):
    global edad
    if edad < 16:
        if not decision:
            nivel = 2
    else:
        if decision:
            if nivel == 99:
                nivel += 1
            elif nivel < 99:
                nivel += 2
        else:
            nivel = 1
    return nivel


def asignarmundo(decision, nivel):
    global edad
    if edad <= 20:
        if not decision:
            mundo = 1
        else:
            if nivel < 50:
                mundo = 2
            else:
                mundo = 3
    else:
        if not decision:
            mundo = 4
        else:
            if nivel < 50:
                mundo = 5
            else:
                mundo = 6
    return mundo


while error:
    codigo = input("Ingrese el código de identificación: ")
    validar(codigo)
    if not error:
        validar2(codigo)
        if not error:
            validar3()

nick = getnick()
decision = getdecision()
nivel = 0
if decision:
    nivel = getnivel()
nivel = asignarnivel(decision, nivel)
mundo = asignarmundo(decision, nivel)
print("{} queda en el mundo {}, nivel {}".format(nick, mundo, nivel))

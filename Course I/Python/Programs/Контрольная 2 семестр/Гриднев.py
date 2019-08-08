class CompanyDatabase:
    """
    CompanyDatabase class
    
    Implements the data operations of companies
    
    Keyword arguments:
    fileName -- The name of the file from which the information will be taken (default 'Гриднев_данные.txt')

    """
    
    def __init__(self, fileName = None):
        """
        Implements the constructor of the class

        """
        if fileName is None:
            self.__data = {}
        else:
            self.__data = self.readFile(fileName)        
        self.__experience = 0
        

    experience = property()

    @experience.getter
    def experience(self):
        """
        Implements property experience

        """
        return self.__experience

    @experience.setter
    def experience(self, value):
        """
        Implements property change sections experience

        Keyword arguments:
        value -- new value of the property

        """
        if type(value) is int:
            self.__experience = value
        else:
            print("Для свойства experience ожидался параметр типа int")

    @experience.deleter
    def experience(self):
        """
        Implements deletion sections slice

        """
        self.__experience = 0
    
    def __str__(self):
        """
        Implements a seal of the class

        """
        return f"Экземпляр содержит {len(self.__data)} компаний"
        
    def __iter__(self):
        """
        Implements an iterator

        """
        return iter(self.__data.keys())

    def __next__(self):
        """
        Implementing the next element of the iterator

        """
        if not hasattr(self, '_iter'):
            self._iter = iter(self.__data.keys())
        
        try:
            return next(self._iter)
        except StopIteration:
            return None
    
    def __getitem__(self, data):
        """
        Implements sections slice

        Keyword arguments:
        data -- slice options

        """
        if isinstance(data, slice):
            if data.start == 0: data.start = 1
            if data.stop == 0: data.stop = 1
            if data.step == 0: data.step = 1
            return list(self.__data.keys())[data.start:data.stop:data.step]
        else:
            try:
                return list(self.__data.keys())[data]
            except IndexError:
                return None
        
    def __iadd__(self, data):
        """
        Overrides the += operator

        Keyword arguments:
        data -- data in tuple format

        """
        if self.__data.get(data[4]) is None:
            self.__data[data[4]] = {data[2]: {"username": data[0], "email": data[1], "name": data[2], "birthdate": data[3], "company": data[4], "job": data[5], "experience": int(data[6]), "address": data[7]}}
        else:
            self.__data[data[4]].update({data[2]: {"username": data[0], "email": data[1], "name": data[2], "birthdate": data[3], "company": data[4], "job": data[5], "experience": int(data[6]), "address": data[7]}})
        return self
            
    def readFile(self, fileName):
        """
        Reads data from a file and writes it to RAM

        Keyword arguments:
        fileName -- file name

        """
        data = {}
        with open(fileName, 'r', encoding="utf-8") as fileOne:
            for line in fileOne:
                line = line.split(" | ")
                if data.get(line[4]) is None:
                    data[line[4]] = {line[2]: {"username": line[0], "email": line[1], "name": line[2], "birthdate": line[3], "company": line[4], "job": line[5], "experience": int(line[6]), "address": line[7]}}
                else:
                    data[line[4]].update({line[2]: {"username": line[0], "email": line[1], "name": line[2], "birthdate": line[3], "company": line[4], "job": line[5], "experience": int(line[6]), "address": line[7]}})
        return data
    
    def writeFile(self, fileName):
        """
        Writes data from RAM to a file

        Keyword arguments:
        fileName -- file name

        """
        with open(fileName, 'w', encoding="utf-8") as fileOne:
            for data in self.__data.values():
                for people in data.values():
                    print(" | ".join([str(people[i]) for i in list(people)]), end="", file=fileOne)
    
    def printInConvenientFormat(self, fileName = "Гриднев_результат.txt"):
        """
        Prints data in tabular format to a file

        Keyword arguments:
        fileName -- file name (default 'Гриднев_результат.txt')

        """
        with open(fileName, 'w', encoding="utf-8") as fileName:
            print(f"{'Ник':<18} {'Почта':<30} {'ФИО':<36} {'Дата рождения':<13} {'Профессия':<20} {'Опыт работы':<12}    {'Адрес':<30}", file = fileName)
            for company, data in self.__data.items():
                print(f"{'---------- ' + company + ' ----------':^166}\n", file = fileName)
                for people in data.values():
                    if self.__experience is not None and people['experience'] >= self.__experience:
                        print(f"{people['username']:<18} {people['email']:<30} {people['name']:<36} {people['birthdate']:<13} {people['job']:<20} {people['experience']:<12} лет {people['address']:<30}", file = fileName)
    
    def averageSeniorityLength(self, company = None):
        """
        Displays statistics on average work experience
        

        Keyword arguments:
        company -- Company name (default None – displays all companies)
            
        """
        if company is None:
            seniorityLength = 0
            countPerson = 0
            for company, data in self.__data.items():
                companySeniorityLength = 0
                companyCountPerson = 0
                for people in data.values():
                    if self.__experience is not None and people['experience'] >= self.__experience:
                        companySeniorityLength += people["experience"]
                        seniorityLength += people["experience"]
                        countPerson += 1
                        companyCountPerson += 1
                try:
                    print(f"\n{company}\nКоличество сотрудников: {companyCountPerson}\nСредний опыт работы: {int(companySeniorityLength/companyCountPerson)}")
                except ZeroDivisionError:
                    print(f"Невозможно получить статистику для компании {company}")
            try:
                print(f"\nСтатистика по всем компаниям:\nОбщее количество сотрудников: {countPerson}\nСредний опыт работы: {int(seniorityLength/countPerson)}")
            except ZeroDivisionError:
                print("Невозможно получить статистику")
        else:
            for companyData, data in self.__data.items():
                if companyData == company:
                    countPerson = 0
                    seniorityLength = 0
                    for people in data.values():
                        if self.__experience is not None and people['experience'] >= self.__experience:
                            seniorityLength += people["experience"]
                            countPerson += 1
                    try:
                        print(f"\n{company}\nКоличество сотрудников: {countPerson}\nСредний опыт работы: {int(seniorityLength/countPerson)}")
                    except ZeroDivisionError:
                        print(f"Невозможно получить статистику для компании {company}")
                    break
    
    def searchPeople(self, name = None):
        """
        Looking for a person profile among all companies
        

        Keyword arguments:
        name -- People name (default None)
            
        """
        if name is not None:
            for data in self.__data.values():
                for people in data.values():
                    if people["name"] == name:
                        print(f"{'-'*30:}\n{name} {people['birthdate']}\nРаботает в компании {people['company']}\nДолжность: {people['job']}\nОпыт работы: {people['experience']}\n\nДанные:\nНик: {people['username']}\nПочта: {people['email']}\nАдрес: {people['address']}\n{'-'*30:}")
                        break
        else:
            print("Вы не ввели имя")
    
    def ratingNumberEmployees(self, reverse = False, company = None):
        data = []
        if company is None:
            for company, companyInfo in self.__data.items():
                data.append([len(companyInfo), company])
        else:
            if company in self.__data:
                return f"{company} {len(self.__data[company])}"
            else:
                return "Нет данных"
        data.sort(key=lambda item: item[0])
        if reverse is False:
            data.reverse()
        return "\n".join([f"{item[0]:>4} {item[1]}" for item in data])

if __name__ == "__main__":
    ### Start ###
#    oneDatabase = CompanyDatabase()
    oneDatabase = CompanyDatabase("Гриднев_данные.txt")
    oneDatabase += "flymedllva", "flymedllva@gmail.com", "Гриднев Дмитрий Владимирович", "01.11.1999", "ООО \"Пофигист\"", "НЕФинансист", 1, "Москва, ул. Рандомная, д. 666, 0" # += 
    for company in oneDatabase: # Итератор
        print(company)
    oneDatabase.experience = 24 # Свойство
    print(oneDatabase.ratingNumberEmployees(reverse = True, company = None)) # Топ компаний по работникам
    oneDatabase.printInConvenientFormat() # Таблица
    oneDatabase.averageSeniorityLength() # Метод, необязательный параметр - название компании, где искать
    oneDatabase.searchPeople("Гриднев Дмитрий Владимирович") # Метод
    print(oneDatabase[1], oneDatabase[-1], oneDatabase[4:6]) # Срезы
    oneDatabase.writeFile("Гриднев_данные_результат.txt") # Сохранение изменений произошедших с данными в первичном виде
    print(f"{next(oneDatabase)} -> {next(oneDatabase)} -> {next(oneDatabase)} -> {next(oneDatabase)}") # Next

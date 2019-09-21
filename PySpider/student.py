from people import People

class Student(People): 
    '''
    学生
    '''

    # 年级
    grade = ''

    def __init__(self, name, age, grade):
        super().__init__(name, age)
        
        self.grade = grade

    def speak(self):
        print('%s 说：我 %d 岁， 上 %s' %(self.name, self.age, self.grade))
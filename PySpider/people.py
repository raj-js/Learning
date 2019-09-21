class People:
    '''
    People 基类
    '''
    
    # 实例属性
    name = ''
    age = 0

    # 私有属性
    __weight = 0

    def __init__(self, name: str, age: int):
        """初始化

        :param name:名字
        :param age:年龄
        """
        self.name = name
        self.age = age

        self.__weight = 30

    def speak(self):
        ''' 说话 '''
        print('%s 说：我 %d 岁' %(self.name, self.age))

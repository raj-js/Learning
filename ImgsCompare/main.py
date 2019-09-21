from PIL import Image

class Comparetor():

    def calculate(self, left, right):
        g = left.histogram()
        s = right.histogram()
        assert len(g) == len(s), "error"

        data = []

        for index in range(0, len(g)):
            if g[index] != s[index]:
                data.append(1 - abs(g[index] - s[index]) / max(g[index], s[index]))
            else:
                data.append(1)

        return sum(data) / len(g)


    def split_image(self, image, part_size):
        pw, ph = part_size
        w, h = image.size

        sub_image_list = []

        assert w % pw == h % ph == 0, "error"

        for i in range(0, w, pw):
            for j in range(0, h, ph):
                sub_image = image.crop((i, j, i + pw, j + ph)).copy()
                sub_image_list.append(sub_image)

        return sub_image_list


    def compare_image(self, path_left, path_right, size=(256, 256), part_size=(64, 64)):
        img_left = Image.open(path_left)
        img_right = Image.open(path_right)

        cvt_img_left = img_left.resize(size).convert("RGB")
        sub_img_left = self.split_image(cvt_img_left, part_size)

        cvt_img_right = img_right.resize(size).convert("RGB")
        sub_img_right = self.split_image(cvt_img_right, part_size)

        sub_data = 0
        for l, r in zip(sub_img_left, sub_img_right):
            sub_data += self.calculate(l, r)

        x = size[0] / part_size[0]
        y = size[1] / part_size[1]

        pre = round((sub_data / (x * y)), 6)
        return pre

comparetor = Comparetor()
rate = comparetor.compare_image("1.png", "2.png")
print(rate)
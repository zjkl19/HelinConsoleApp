

# -*- coding: utf-8 -*-
"""
Created on Mon Apr 22 20:16:38 2019

@author: Administrator
"""
import numpy as np

import matplotlib.pyplot as plt
import matplotlib.ticker as ticker

from brokenaxes import brokenaxes

#定义函数来显示柱状上的数值
def autolabel(rects):
    for rect in rects:
        height = rect.get_height()
        plt.text(rect.get_x()+rect.get_width()/2.-0.15, 1.03*height, '%s' % float(height))


plt.rcParams['font.sans-serif']=['SimHei'] #用来正常显示中文标签
plt.rcParams['axes.unicode_minus']=False #用来正常显示负号 

# 创建一个点数为 8 x 6 的窗口, 并设置分辨率为 80像素/每英寸
plt.figure(figsize=(8, 6), dpi=80)

# 再创建一个规格为 1 x 1 的子图
plt.subplot(1, 1, 1)

# 柱子总数
N = 4
# 包含每个柱子对应值的序列
values = [983272,15157,1433,140]
multiples = [x/sum(values) for x in values]

bax = brokenaxes(ylims=((0, 20000), (80000, 100000)))

# 包含每个柱子下标的序列
index = np.arange(N)

# 柱子的宽度
width = 0.35

# 绘制柱状图, 每根柱子的颜色为紫罗兰色
p2 = plt.bar(index, values, width, color="#87CEFA")
autolabel(p2)

# 设置横轴标签
#plt.xlabel('Months')
# 设置纵轴标签
plt.ylabel('数量')

# 添加标题
#plt.title('Monthly average rainfall')

# 添加纵横轴的刻度
plt.xticks(index, ('0~10t\n(%.2f%%'%(100*multiples[0])+')', '10~20t\n(%.2f%%'%(100*multiples[1])+')', '20~30t\n(%.2f%%'%(100*multiples[2])+')', '30t以上\n(%.2f%%'%(100*multiples[3])+')'))

#plt.yticks(np.arange(0, 81, 10))

# 添加图例
plt.legend(loc="upper right")

plt.show()
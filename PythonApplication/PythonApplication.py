

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
        plt.text(rect.get_x()+rect.get_width()/2.-0.23, 1.03*height, '%s' % height,fontsize=15)

fontSize=15
#plt.rcParams['figure.figsize'] = (8.0, 6.0)
plt.rcParams['font.sans-serif']=['SimHei'] #用来正常显示中文标签
plt.rcParams['axes.unicode_minus']=False #用来正常显示负号 
plt.xticks(fontsize=fontSize)
plt.yticks(fontsize=fontSize)

# 包含每个柱子对应值的序列
#values = [983272,15157,1433,140]

x_data = [1, 2, 3, 4]
#y_data = [983272,15157,1433,140]    #车重
y_data = [17091,31998,91890,237471]    #车速
multiples = [x/sum(y_data) for x in y_data]

xticksPrefix=['0～10t','10～20t','20～30t','30t以上']

# 柱子总数
N =len(y_data)
# 包含每个柱子下标的序列
index = np.arange(N)

#bax = brokenaxes(ylims=((0, 20000), (80000, 100000)))

bax=plt

# 柱子的宽度
width = 0.5

# 绘图
p2=bax.bar(x_data,y_data, label='动态称重', color='steelblue',width=width,alpha=0.8)

autolabel(p2)

# 在柱状图上显示具体数值, ha参数控制水平对齐方式, va控制垂直对齐方式
#for x, y in enumerate(y_data):
#    bax.text(x, y + 100, '%s' % y, ha='center', va='bottom')
# 设置标题
#plt.title("Java与Android图书对比")

# 为两条坐标轴设置名称
#plt.xlabel("年份")
plt.ylabel("数量",fontsize=15)

# 添加纵横轴的刻度
xticksLabel=['%s'%(xticksPrefix[0])+'\n(%.2f%%'%(100*multiples[0])+')']
for i in range(len(xticksPrefix)):


plt.xticks(x_data, ['%s'%(xticksPrefix[0])+'\n(%.2f%%'%(100*multiples[0])+')', '%s'%(xticksPrefix[1])+'\n(%.2f%%'%(100*multiples[1])+')', '%s'%(xticksPrefix[2])+'\n(%.2f%%'%(100*multiples[2])+')', '%s'%(xticksPrefix[3])+'\n(%.2f%%'%(100*multiples[3])+')'])

#plt.xticks([])
ax = plt.gca()
ax.spines['top'].set_visible(False)
ax.spines['right'].set_visible(False)
#ax.spines['bottom'].set_visible(False)
#ax.spines['left'].set_visible(False)

# 显示图例
#plt.legend()
plt.savefig('tmp.pdf', bbox_inches='tight')
plt.show()


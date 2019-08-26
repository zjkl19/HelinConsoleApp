

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
def autolabel(rects,y_data):
    i=0
    space=-0.20
    for rect in rects:
        if 100>y_data[i]>=0:
            space=-0.05
        elif 1000>y_data[i]>=100:
            space=-0.08
        elif 10000>y_data[i]>=1000:
            space=-0.10
        elif 100000>y_data[i]>=10000:
            space=-0.18
        elif 1000000>y_data[i]>=100000:
            space=-0.20
        else:
            space=-0.26
        height = rect.get_height()
        plt.text(rect.get_x()+rect.get_width()/2.+space*5.0, 1.03*height, '%s' % height,fontsize=15)
        i=i+1
fontSize=15
#plt.rcParams['figure.figsize'] = (8.0, 6.0)
plt.rcParams['font.sans-serif']=['SimHei'] #用来正常显示中文标签
plt.rcParams['axes.unicode_minus']=False #用来正常显示负号 
plt.xticks(fontsize=fontSize)
plt.yticks(fontsize=fontSize)

totalDays=7    #总天数

# 包含每个柱子对应值的序列
y_data = [333943,5105,639,54]    #车重
y_data = [77929,97206,89124,75482]    #车道
y_data = [38635,204613,91268,5225]    #车速
#y_data = [int(77929/totalDays),int(97206/totalDays),int(89124/totalDays),int(75482/totalDays)]    #不同车道日均车辆数
y_data = [8915,4994,4784,26106,38978,37899,31443,38116,41328,39592,40428,27157]    #不同小时车辆总数
y_data = [59.2,61.0,60.1,47.2,33.6,41.3,49.0,42.4,38.9,38.0,44.2,51.6]    #不同小时平均车速

y_data = [59.2,61.0,60.1,47.2,33.6,41.3,49.0,42.4,38.9,38.0,44.2,51.6]    #不同小时平均车速

x_data = range(1,len(y_data)+1)
multiples = [x/sum(y_data) for x in y_data]

xticksPrefix=['0～10t','10～20t','20～30t','30t以上']    #车重
xticksPrefix=['车道1','车道2','车道3','车道4']    #车道
xticksPrefix=['0～30km/h','30～50km/h','50～70km/h','70km/h以上']    #车速
xticksPrefix=['0～2','2～4','4～6','6～8','8～10','10～12','12～14','14～16','16～18','18～20','20～22','22～24']    #小时

xticksPrefix=['0～2','2～4','4～6','6～8','8～10','10～12','12～14','14～16','16～18','18～20','20～22','22～24']    #小时

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

autolabel(p2,y_data)

# 在柱状图上显示具体数值, ha参数控制水平对齐方式, va控制垂直对齐方式
#for x, y in enumerate(y_data):
#    bax.text(x, y + 100, '%s' % y, ha='center', va='bottom')
# 设置标题
#plt.title("Java与Android图书对比")

# 为两条坐标轴设置名称
#plt.xlabel("年份")
plt.ylabel("车速（km/h）",fontsize=15)

# 添加纵横轴的刻度
#xticksLabel=['%s'%(xticksPrefix[0])+'\n(%.2f%%'%(100*multiples[0])+')']
#for i in range(len(xticksPrefix)):
#    plt.xticks(x_data, ['%s'%(xticksPrefix[0])+'\n(%.2f%%'%(100*multiples[0])+')', '%s'%(xticksPrefix[1])+'\n(%.2f%%'%(100*multiples[1])+')', '%s'%(xticksPrefix[2])+'\n(%.2f%%'%(100*multiples[2])+')', '%s'%(xticksPrefix[3])+'\n(%.2f%%'%(100*multiples[3])+')'])

# 添加纵横轴的刻度(不含比例)
#xticksLabel=['%s'%(xticksPrefix[0])]
#for i in range(len(xticksPrefix)):
#    plt.xticks(x_data, ['%s'%(xticksPrefix[0]), '%s'%(xticksPrefix[1]), '%s'%(xticksPrefix[2]), '%s'%(xticksPrefix[3])])

xticksLabel=['%s'%(xticksPrefix[0])+'\n(%.2f%%'%(100*multiples[0])+')']
for i in range(1,len(xticksPrefix)):
    xticksLabel=xticksLabel+['%s'%(xticksPrefix[i])+'\n(%.2f%%'%(100*multiples[i])+')']

xticksLabel=['%s'%(xticksPrefix[0])]
for i in range(1,len(xticksPrefix)):
    xticksLabel=xticksLabel+['%s'%(xticksPrefix[i])]

xticksLabel=['%s'%(xticksPrefix[0])]
for i in range(1,len(xticksPrefix)):
    xticksLabel=xticksLabel+['%s'%(xticksPrefix[i])]


plt.xticks(x_data, xticksLabel)


#plt.xticks([])
ax = plt.gca()
ax.spines['top'].set_visible(False)
ax.spines['right'].set_visible(False)
#ax.spines['bottom'].set_visible(False)
#ax.spines['left'].set_visible(False)

# 显示图例
#plt.legend()
#plt.savefig('tmp.pdf', bbox_inches='tight')
plt.show()


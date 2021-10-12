def mean_a(data,column):
        row_iterator = data.iterrows()
        summ = 0
        count = 0 
        for i, row in row_iterator:
            summ += row[column]
            count +=1
        return summ/count

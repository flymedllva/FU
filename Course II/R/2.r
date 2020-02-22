# 1
(x <- 10:14)
(x <- x[length(x)]:x[1])
(x <- 10.1:14)
rep(seq(0, 60, 15), times = 3)
rep(1, times=3)
seq(0, 1, 0.1)
seq(10, -10, length.out = 5)

# 2
LETTERS[1:30]
(g <- letters[1:30])
rev(g)

# 3
(x <- 2:11)
x[4]
x[-5]
x[4:6]
x[-(3:2)]
(names(x) <- c("1", 2))
x["1"]
# 4

g <- matrix(1:6, 2)
dim(g)
cbind(g, g)
rbind(g, g)
x <- 0:5
y <- 5:10
z <- 10:15
(ma <- cbind(x, y, z))
(ma <- rbind(x, y, z))

# 5 шахматы
l <- letters[1:8]
r <- 1:8
matrix(sapply(r, function (i) paste0(l, i)), ncol = length(r), nrow = length(l), dimnames = list(r, l))

# 6 таблица умножения

n <- 10
matrix(1:n%o%1:n, nrow = n, ncol = n, dimnames = list(paste0('*', 1:n), paste0('*', 1:n)))

# или так или через sapply/apply
z <- 1:n
matrix(cbind(z*1, z*2, z*3, z*4, z*5, z*6, z*7, z*8, z*9, z*10), ncol = 10, nrow = 10, byrow = TRUE, dimnames = list(paste0('*', 1:n), paste0('*', 1:n)))

# 7 сдвиг

l <- length(letters)
matrix(letters[(matrix(rep(seq(l), each=l), nrow=l, byrow=FALSE) - matrix(rep(seq(l), each=l), nrow=l, byrow=TRUE)) %% l + 1], nrow=l, byrow=FALSE);
# Я вы выбрал цикл конечно :/ но задача была поугарать с использования только средст лекции
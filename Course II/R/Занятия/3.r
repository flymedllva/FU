# 1
a <- c(1, 1, 2);
b <- c(0, -4, 3);
# .1
-4 * a + 5 * b;
# .2
as.numeric(2 * (a %*% b)) * a - 3 * norm(b, type='2') * b;


# 2
a <- c(2, 0, -3);
b <- c(6, 1, 4);
norm(a, type="2");
norm(b, type="2");
a %*% b;
if (a %*% b == 0) {
  "Векторы ортогoнальны";
} else {
  "Векторы не ортогoнальны";
}


# 3
a <- rep(1:4, each=2);
b <- -2:5;
na <- norm(a, type="2");
nb <- norm(b, type="2");

if (na > nb) {
  "Вектор a длиннее b";
} else {
  "Вектор b длиннее a";
}

cos_ab <- (a %*% b) / (na * nb);
if (cos_ab > 0) {
  "Острый угол";
} else if (cos_ab < 0) {
  "Тупой угол";
} else {
  "Угол установки";
}


# 4
max_vector <- NULL;
a <- c(1:6, 0,3,1,0,7,4, 4,4,3,3,1,1, -2,2,2,2,-2,2, 1,0,9,0,8,0, 1,-3,-5,-5,3,2);
A <- matrix(a, nrow=6, ncol=6);
max_norm <- 0;
max_index <- 0;

for(col in seq_len(ncol(A))) {
  curr_norm <- norm(A[, col], type='2');
  if (curr_norm > max_norm) {
    max_norm <- curr_norm;
    max_index <- col;
  }
}

A[, max_index];


# 5
for(col1 in 1:(ncol(A) - 1)) {
  for(col2 in (col1 + 1):ncol(A)) {
    if (A[, col1] %*% A[, col2] == 0) {
      print(A[,col1]);
      print(A[,col2]);
    }
  }
}


# 6
q <- c(-1, 2, 0,   3, -1, 0,   1, 4, 1);
e <- c(1, 0, 0,   0, 1, 0,   0, 0, 1);
p <- c(rep(0:0, each=4), -3, 4,    rep(1:1, each=6),  rep(2:2, each=6));
Q <- matrix(q, nrow=3, ncol=3);
E <- matrix(e, nrow=3, ncol=3);
P <- matrix(p, nrow=3, ncol=6);

# .1
dim(Q);
dim(E);
dim(P);

# .2
-4 * Q + 5 * E;

# .3
t(Q) * Q - E;

# .4
Q %*% Q %*% Q;

# .5
det(Q);
det(Q %*% Q);

# .6
sqrt(Q - 2 * E)

# .7
solve(Q);

# .8
require(Matrix)
rankMatrix(P)[1]
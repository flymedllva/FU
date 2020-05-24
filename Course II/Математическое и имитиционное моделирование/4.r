

get_diag <- function(mat){
  t <- vector()
  for (i in 1:nrow(mat)){
    t<-c(t, mat[i, i])
  }
  t
}

get_p <- function(mat, n){
  get_diag(pow(mat, n))
}

get_f <- function(mat, k){
  if (k==1){
    return(get_diag(mat))
  }
  s <- get_p(mat, k)
  l <- k - 1
  for (m in 1:l){
    s <- s - get_f(mat, m)*get_p(mat, k-m)
  }
  s
}

get_diag2 <- function(mat){
  for (i in 1:nrow(mat)){
    for (j in 1:nrow(mat)){
      if (i!=j){
        mat[i,j]<-0
      }
    }
  }
  mat
}

get_p2 <- function(mat, n){
  get_diag2(pow(mat, n))
}

get_f2 <- function(mat, k){
  if (k==1){
    return(get_diag2(mat))
  }
  s <- get_p2(mat, k)
  l <- k - 1
  for (m in 1:l){
    s <- s - get_f2(mat, m)*get_p2(mat, k-m)
  }
  s
}
mat <- matrix(c(0.5, 0.4, 0.1, 0.25, 0.25, 0.5, 0.1, 0.2, 0.7), 3, 3)

get_f(mat, )

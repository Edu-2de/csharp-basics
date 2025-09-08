public class ContaCorrente : ITributavel{
  public double CalcularTributo(){
    return Saldo * 0.05;
  }

  public double CalcularTributo(double aliquota){
    return Saldo * aliquota;
  }
}

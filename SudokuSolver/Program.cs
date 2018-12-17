using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows;

namespace SudokuSolver
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Sudoku sudo = new Sudoku();
        }
    }
    /// <summary>
    /// 스도쿠 클래스입니다.
    /// </summary>
    public class Sudoku {
        /// <summary>
        /// 어떤 써머리?
        /// </summary>
        enum SELECTED {ROW =0, COL, DIAG, TURN, NUMC};
        
        private int[,] position = new int[9,9];
        /// <summary>
        /// 스도쿠 row행, col 열에 있는 원소값을 가져옵니다.
        /// </summary>
        /// <param name="row">스도쿠의 가로 위치. 위에서부터 0으로 셉니다.\n가용 값:[0~8]</param>
        /// <param name="col">스도쿠의 세로 위치. 왼쪽에서부터 0으로 셉니다.\n가용 값:[0~8]</param>
        /// <returns>해당 row, col 위치의 값을 리턴합니다.</returns>
        public int Value(int row, int col) {
            return position[row, col];
        }

        /// <summary>
        /// open file dialog 를 띄워 파일을 열어줄 계획입니다.
        /// </summary>
        /// <returns></returns>
        public static Sudoku Load() {
            Sudoku loadedsudoku = new Sudoku();
            
            
            return loadedsudoku;
        }
        public static Sudoku Load(string filename) {
            return null;
        }
        public Sudoku() {

        }

        private void setSudoku(Sudoku msudo) {
            Array.Copy(msudo.position, position,position.GetLength(0)*position.GetLength(1));
        }

        public void setRandomSudoku() {
            this.setSudoku(Sudoku.Load("sample.sudoku"));
            Random randomer = new Random();
            int Rcount = randomer.Next(20, 255);
            SELECTED mslected;
            int fval, sval;
            for(int i =0; i<Rcount; i++) {
                mslected = (SELECTED)randomer.Next(0,4);
                fval = randomer.Next(0, 8);
                sval = randomer.Next(0, 8);
                Rand(mslected, fval, sval);
            }
        }
        private void Rand(SELECTED mselect, int fvalue, int svalue) {
            switch (mselect) {
                case SELECTED.ROW:
                    if (Math.Abs(fvalue - svalue) < 3) {
                        int[] temp = new int[9];
                        for(int i=0; i<9; i++) {
                            temp[i] = position[fvalue, i];
                            position[fvalue, i] = position[svalue, i];
                            position[svalue, i] = temp[i];
                        }
                    } else {
                        int fir = fvalue / 3;
                        fir *= 3;
                        int sec = svalue / 3;
                        sec *= 3;
                        for(int i =0; i<3; i++) {
                            for(int j=0; j<9; j++) {
                                int temp = 0;
                                temp = position[fir + i, j];
                                position[fir + i, j] = position[sec + i, j];
                                position[sec + i, j] = temp;
                            }
                        }
                    }
                    break;
                case SELECTED.COL:
                    if (Math.Abs(fvalue - svalue) < 3) {
                        int[] temp = new int[9];
                        for (int i = 0; i < 9; i++) {
                            temp[i] = position[i,fvalue];
                            position[i,fvalue] = position[i,svalue];
                            position[i,svalue] = temp[i];
                        }
                    } else {
                        int fir = fvalue / 3;
                        fir *= 3;
                        int sec = svalue / 3;
                        sec *= 3;
                        for (int i = 0; i < 3; i++) {
                            for (int j = 0; j < 9; j++) {
                                int temp = 0;
                                temp = position[j,fir+i];
                                position[j,fir+i] = position[j,sec+i];
                                position[j,sec+i] = temp;
                            }
                        }
                    }
                    break;
                case SELECTED.DIAG:
                    switch (fvalue/5) {
                        case 0:

                            break;
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                            break;
                    }
                    break;
                case SELECTED.TURN:
                    break;
                case SELECTED.NUMC:
                    break;
                default:
                    break;
            }
        }
        public void Show() {
            Console.Clear();
            Console.WriteLine("┌───────────────┐");
            for (int i =0; i < 81; i++) {
                Console.Write("│{0} ", position[i/9,i%9]);
                if (i % 9 == 8) {
                    Console.WriteLine("│");
                }
            }
            Console.WriteLine("└───────────────┘");
        }

    }
}
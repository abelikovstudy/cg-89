using System.Drawing.Imaging;

namespace cg_lab89.Render
{
    public unsafe class FastBitmap : IDisposable
    {
        public readonly int Width;

        public readonly int Height;

        public int Count => Height * Width;

        /// <summary>
        /// Bitmap, из которого был создан этот экземпляр FastBitmap.
        /// Хранится, чтобы потом можно было разблокировать.
        /// </summary>
        private readonly Bitmap _source;

        /// <summary>
        /// Данные о Bitmap.
        /// Хранится, чтобы потом можно было разблокировать.
        /// </summary>
        private readonly BitmapData _bitmapData;

        /// <summary>
        /// Количество байт, отведённое на один пиксель в формате изображения.
        /// </summary>
        private readonly int _bytesPerPixel;

        /// <summary>
        /// Количество байт, отведённое на одну строку в формате изображения.
        /// </summary>
        private readonly int _stride;

        /// <summary>
        /// Указатель на начало байтового потока, которым закодирована картинка.
        /// </summary>
        private readonly byte* _scan0;

        /// <summary>
        /// PixelFormat, к которому мы переводим любой Bitmap.
        /// </summary>
        private const PixelFormat TargetPixelFormat = PixelFormat.Format32bppArgb;

        public FastBitmap(Bitmap bitmap)
        {
            Width = bitmap.Width;
            Height = bitmap.Height;
            _source = bitmap;
            // Блокируем данные о Bitmap в оперативной памяти
            _bitmapData = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadWrite,
                TargetPixelFormat
            );
            _stride = _bitmapData.Stride;
            _bytesPerPixel = Image.GetPixelFormatSize(TargetPixelFormat) / 8;
            _scan0 = (byte*)_bitmapData.Scan0.ToPointer();
        }

        /// <summary>
        /// Возвращает указатель на расположение пикселя в памяти
        /// </summary>
        /// <param name="point">Координаты пикселя</param>
        private byte* PixelOffset(Point point)
            =>
                _scan0 // Указатель на начало потока байтов Bitmap
                + point.Y * _stride // Сдвиг Y-той строки
                + point.X * _bytesPerPixel; // Сдвиг X-того пикселя

        public void SetPixel(Point point, Color color)
        {
            if (point.X >= Width || point.X <= 0 || point.Y >= Height || point.Y <= 0)
            {
                return;
            }
            var data = PixelOffset(point);
            data[3] = color.A;
            data[2] = color.R;
            data[1] = color.G;
            data[0] = color.B;
        }

        public Color GetPixel(Point point)
        {
            var data = PixelOffset(point);
            return Color.FromArgb(
                data[3],
                data[2],
                data[1],
                data[0]
            );
        }

        public Color this[int x, int y]
        {
            get => GetPixel(new Point(x, y));
            set => SetPixel(new Point(x, y), value);
        }

        /// <summary>
        /// Перемещает данные Bitmap обратно в видеопамять.
        /// При использовании using вызывается автоматически.
        /// </summary>
        public void Dispose()
        {
            _source.UnlockBits(_bitmapData);

            GC.Collect();
            //GC.WaitForPendingFinalizers();
        }
    }

}

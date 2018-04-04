using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel; 
using System.Text.RegularExpressions;

namespace App
{
    /// <summary>文件及文件夹静态操作类</summary>
    [Serializable]
    public static class FileSys
    {
        /// <summary>操作发生错误时产生的错误对象</summary>
        private static Exception _Exception;

        /// <summary>操作发生错误时产生的错误对象</summary>
        public static Exception OperError
        {
            get { return FileSys._Exception; }
            set { FileSys._Exception = value; }
        }

        /// <summary>新建文件</summary>
        /// <param name="inPath">需要新建的文件全路径</param>
        /// <returns>成功返回 true 失败返回 false</returns>
        public static bool NewFile(string inPath)
        {
            return NewFile(inPath, true);
        }

        /// <summary>新建文件</summary>
        /// <param name="inPath">需要新建的文件全路径</param>
        /// <param name="isWrite">该值为true,则创建并改写文件，否则只创建文件</param>
        /// <returns>成功返回 true 失败返回 false</returns>
        public static bool NewFile(string inPath, bool isWrite)
        {
            _Exception=null;
            try
            {
                if (isWrite)
                {
                    File.Create(inPath);
                }
                else 
                {
                    if (!File.Exists(inPath))
                    {
                        File.Create(inPath);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                _Exception = ex;
                return false;
            }
        }

        /// <summary>删除文件</summary>
        /// <param name="inPath">需要删除的文件全路径</param>
        /// <returns>成功返回 true 失败返回 false</returns>
        public static bool DelFile(string inPath)
        {
            _Exception = null;
            try
            {
                if (File.Exists(inPath))
                {
                    File.Delete(inPath);
                } 
                return true;
            }
            catch (Exception ex)
            {
                _Exception = ex;
                return false;
            }
        }

        /// <summary>取消文件只读属性</summary>
        /// <param name="inPath">需要取消只读属性的文件全路径</param>
        /// <returns>取消成功返回 true 失败返回 false</returns>
        public static bool SetFileNormal(string inPath)
        {
            _Exception = null;
            try
            {
                if (File.Exists(inPath))
                {
                    FileInfo fi = new FileInfo(inPath);
                    if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                    {
                        fi.Attributes = FileAttributes.Normal;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                _Exception = ex;
                return false;
            }
        }

        /// <summary>返回文件路径内的文件名</summary>
        /// <param name="paths">文件路径</param>
        /// <returns>返回文件路径内的文件名</returns>
        public static string GetFileName(string paths) 
        {
            try
            {
                return paths.Substring(paths.LastIndexOf("\\") + 1, (paths.LastIndexOf(".") - paths.LastIndexOf("\\") - 1)).Trim();
            }
            catch 
            {
                return "";
            }   
        }

        /// <summary>返回文件路径内的文件扩展名</summary>
        /// <param name="paths">文件路径</param>
        /// <returns>返回文件路径内的文件扩展名</returns>
        public static string GetFileExtension(string paths) 
        {
            try
            {
                return paths.Substring(paths.LastIndexOf(".") + 1, (paths.Length - paths.LastIndexOf(".") - 1)).Trim();
            }
            catch
            {
                return "";
            }     
        }

        /// <summary>新建文件夹，新建成功返回 true 新建失败返回 false</summary>
        /// <param name="path">要新建的文件夹路径，路径末尾必须携带"\"。</param>
        /// <returns>新建成功返回 true 新建失败返回 false</returns>
        public static bool NewDir(string path)
        {
            string errStr = "";
            return NewDir(path, ref errStr);
        }

        /// <summary>移动文件夹，移动成功返回 true 移动失败返回 false</summary>
        /// <param name="path">要移动的文件夹路径，路径末尾必须携带"\"。</param>
        /// <param name="mpath">移动到的目的路径，路径末尾必须携带"\"。</param>
        /// <returns>移动成功返回 true 移动失败返回 false</returns>
        public static bool MoveDir(string path, string mpath)
        {
            string errStr = "";
            return MoveDir(path, mpath, ref errStr);
        }

        /// <summary>复制文件夹，复制成功返回 true 复制失败返回 false</summary>
        /// <param name="path">要复制的文件夹路径，路径末尾必须携带"\"。</param>
        /// <param name="mpath">复制到的目的路径，路径末尾必须携带"\"。</param>
        /// <returns>复制成功返回 true 复制失败返回 false</returns>
        public static bool CopyDir(string path, string mpath)
        {
            string errStr = "";
            return CopyDir(path, mpath, ref errStr);
        }

        /// <summary>删除文件夹，删除成功返回 true 删除失败返回 false</summary>
        /// <param name="path">要删除的文件夹路径，路径末尾必须携带"\"。</param>
        /// <returns>删除成功返回 true 删除失败返回 false</returns>
        public static bool DelDir(string path)
        {
            string errStr = "";
            return DelDir(path, ref errStr);
        }

        /// <summary>新建文件夹，新建成功返回 true 新建失败返回 false</summary>
        /// <param name="path">要新建的文件夹路径，路径末尾必须携带"\"。</param>
        /// <param name="errStr">发生错误时返回的错误信息</param>
        /// <returns>新建成功返回 true 新建失败返回 false</returns>
        public static bool NewDir(string path,ref string errStr)
        {
            _Exception = null;
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                return true;
            }
            catch (Exception ex)
            {
                _Exception = ex;
                errStr = ex.Message;
                return false;
            }
        }

        /// <summary>移动文件夹，移动成功返回 true 移动失败返回 false</summary>
        /// <param name="path">要移动的文件夹路径，路径末尾必须携带"\"。</param>
        /// <param name="mpath">移动到的目的路径，路径末尾必须携带"\"。</param>
        /// <param name="errStr">发生错误时返回的错误信息</param>
        /// <returns>移动成功返回 true 移动失败返回 false</returns>
        public static bool MoveDir(string path, string mpath, ref string errStr)
        {
            _Exception = null;
            try
            {
                Directory.Move(Path.GetDirectoryName(path), Path.GetDirectoryName(mpath));
                return true;
            }
            catch (Exception ex)
            {
                _Exception = ex;
                errStr = ex.Message;
                return false;
            }
        }

        /// <summary>复制文件夹，复制成功返回 true 复制失败返回 false</summary>
        /// <param name="path">要复制的文件夹路径，路径末尾必须携带"\"。</param>
        /// <param name="mpath">复制到的目的路径，路径末尾必须携带"\"。</param>
        /// <param name="errStr">发生错误时返回的错误信息</param>
        /// <returns>复制成功返回 true 复制失败返回 false</returns>
        public static bool CopyDir(string path, string mpath, ref string errStr)
        {
            _Exception = null;
            try
            {
                path = Path.GetDirectoryName(path);
                mpath = Path.GetDirectoryName(mpath);
                CopyDirs(path, mpath);
                return true;
            }
            catch (Exception ex)
            {
                _Exception = ex;
                errStr = ex.Message;
                return false;
            }
        }

        /// <summary>复制文件夹操作</summary>
        /// <param name="path">要复制的文件夹路径，路径末尾必须携带"\"。</param>
        /// <param name="mpath">复制到的目的路径，路径末尾必须携带"\"。</param>
        public static void CopyDirs(string path, string mpath)
        {
            _Exception = null;
            try
            {
                // 检查目标目录是否以目录分割字符结束如果不是则添加之 
                if (mpath[mpath.Length - 1] != Path.DirectorySeparatorChar)
                {
                    mpath += Path.DirectorySeparatorChar;
                }
                // 判断目标目录是否存在如果不存在则新建之 
                if (!Directory.Exists(mpath))
                {
                    Directory.CreateDirectory(mpath);
                }
                // 得到源目录的文件列表，该里面是包含文件以及目录路径的一个数组  
                string[] fileList = Directory.GetFileSystemEntries(path);
                // 遍历所有的文件和目录 
                foreach (string file in fileList)
                {
                    // 先当作目录处理如果存在这个目录就递归Copy该目录下面的文件 
                    if (Directory.Exists(file))
                    {
                        CopyDirs(file, mpath + Path.GetFileName(file));
                    }
                    else
                    {
                        File.Copy(file, mpath + Path.GetFileName(file), true);
                    }
                }
            }
            catch (Exception ex)
            {
                _Exception = ex;
            }
        }

        /// <summary>删除文件夹，删除成功返回 true 删除失败返回 false</summary>
        /// <param name="path">要删除的文件夹路径，路径末尾必须携带"\"。</param>
        /// <param name="errStr">发生错误时返回的错误信息</param>
        /// <returns>删除成功返回 true 删除失败返回 false</returns>
        public static bool DelDir(string path, ref string errStr)
        {
            _Exception = null;
            try
            {
                string p = Path.GetDirectoryName(path);
                if (Directory.Exists(p))
                {
                    Directory.Delete(p, true);
                }    
                return true;
            }
            catch (Exception ex)
            {
                _Exception = ex;
                errStr = ex.Message;
                return false;
            }
        }

        /// <summary>取消文件夹只读属性</summary>
        /// <param name="inPath">需要取消只读属性的文件夹全路径</param>
        /// <returns>取消成功返回 true 失败返回 false</returns>
        public static bool SetDirNormal(string inPath)
        {
            _Exception = null;
            try
            {
                string p = Path.GetDirectoryName(inPath);
                if (Directory.Exists(p))
                {
                    DirectoryInfo DirInfo = new DirectoryInfo(p);
                    DirInfo.Attributes = FileAttributes.Normal & FileAttributes.Directory;
                }
                return true;
            }
            catch(Exception ex)
            {
                _Exception = ex;
                return false;
            }
        }

        /// <summary>取消文件夹内所有文件及文件夹只读属性</summary>
        /// <param name="inPath">需要取消只读属性的文件夹全路径</param>
        /// <returns>取消成功返回 true 失败返回 false</returns>
        public static bool SetAllDirFileNormal(string inPath)
        {
            _Exception = null;
            try
            {
                List<string> files = new List<string>();
                List<string> paths = new List<string>();
                GetAllDirFiles(inPath, 9999999, ref files, ref paths);
                for (int i = 0; i < files.Count ; i++ )
                {
                    SetFileNormal(files[i]);
                    SetDirNormal(files[i]);
                }
                for (int i = 0; i < paths.Count; i++)
                {
                    SetDirNormal(paths[i]);
                }
                return true;
            }
            catch (Exception ex)
            {
                _Exception = ex;
                return false;
            }
        }

        /// <summary>获取指定目录下(子目录深度最大1000级)所有文件相对路径及空文件夹相对路径，分别返回到files及paths</summary>
        /// <param name="path">指定目录(物理路径)</param>
        /// <param name="thispath">根路径</param>
        /// <param name="files">返回所有文件相对路径列表</param>
        /// <param name="paths">返回所有空文件夹相对路径列表</param>
        public static void GetAllDirFiles(string path, string thispath, ref List<string> files, ref List<string> paths)
        {
            int lv = 0;
            pGetAllDirFiles(path, thispath, "", "", 1000, ref files, ref paths, ref lv);
        }

        /// <summary>获取指定目录下(子目录深度最大1000级)所有文件路径及空文件夹路径，分别返回到files及paths</summary>
        /// <param name="path">指定目录(物理路径)</param>
        /// <param name="files">返回所有文件路径列表</param>
        /// <param name="paths">返回所有空文件夹路径列表</param>
        public static void GetAllDirFiles(string path, ref List<string> files, ref List<string> paths)
        {
            int lv = 0;
            pGetAllDirFiles(path, "", "", 1000, ref files, ref paths, ref lv);
        }

        /// <summary>获取指定目录下所有文件相对路径及空文件夹相对路径，分别返回到files及paths</summary>
        /// <param name="path">指定目录(物理路径)</param>
        /// <param name="thispath">根路径</param>
        /// <param name="dirlv">子目录最大深度</param>
        /// <param name="files">返回所有文件相对路径列表</param>
        /// <param name="paths">返回所有空文件夹相对路径列表</param>
        public static void GetAllDirFiles(string path, string thispath, int dirlv, ref List<string> files, ref List<string> paths)
        {
            int lv = 0;
            pGetAllDirFiles(path, thispath, "", "", dirlv, ref files, ref paths, ref lv);
        }

        /// <summary>获取指定目录下所有文件路径及空文件夹路径，分别返回到files及paths</summary>
        /// <param name="path">指定目录(物理路径)</param>
        /// <param name="dirlv">子目录最大深度</param>
        /// <param name="files">返回所有文件路径列表</param>
        /// <param name="paths">返回所有空文件夹路径列表</param>
        public static void GetAllDirFiles(string path, int dirlv, ref List<string> files, ref List<string> paths)
        {
            int lv = 0;
            pGetAllDirFiles(path, "", "", dirlv, ref files, ref paths, ref lv);
        }

        /// <summary>获取指定目录下(子目录深度最大1000级)所有文件相对路径及空文件夹相对路径，分别返回到files及paths</summary>
        /// <param name="path">指定目录(物理路径)</param>
        /// <param name="thispath">根路径</param>
        /// <param name="files">返回所有文件相对路径列表</param>
        /// <param name="paths">返回所有空文件夹相对路径列表</param>
        /// <param name="searchpath">要与path中的目录名匹配的搜索字符串</param>
        /// <param name="searchfile">要与path中的文件名匹配的搜索字符串</param>
        public static void GetAllDirFiles(string path, string thispath, ref List<string> files, ref List<string> paths, string searchpath, string searchfile)
        {
            int lv = 0;
            pGetAllDirFiles(path, thispath, searchpath, searchfile, 1000, ref files, ref paths, ref lv);
        }

        /// <summary>获取指定目录下(子目录深度最大1000级)所有文件路径及空文件夹路径，分别返回到files及paths</summary>
        /// <param name="path">指定目录(物理路径)</param>
        /// <param name="files">返回所有文件路径列表</param>
        /// <param name="paths">返回所有空文件夹路径列表</param>
        /// <param name="searchpath">要与path中的目录名匹配的搜索字符串</param>
        /// <param name="searchfile">要与path中的文件名匹配的搜索字符串</param>
        public static void GetAllDirFiles(string path, ref List<string> files, ref List<string> paths, string searchpath, string searchfile)
        {
            int lv = 0;
            pGetAllDirFiles(path, searchpath, searchfile, 1000, ref files, ref paths, ref lv);
        }

        /// <summary>获取指定目录下所有文件相对路径及空文件夹相对路径，分别返回到files及paths</summary>
        /// <param name="path">指定目录(物理路径)</param>
        /// <param name="thispath">根路径</param>
        /// <param name="dirlv">子目录最大深度</param>
        /// <param name="files">返回所有文件相对路径列表</param>
        /// <param name="paths">返回所有空文件夹相对路径列表</param>
        /// <param name="searchpath">要与path中的目录名匹配的搜索字符串</param>
        /// <param name="searchfile">要与path中的文件名匹配的搜索字符串</param>
        public static void GetAllDirFiles(string path, string thispath, int dirlv, ref List<string> files, ref List<string> paths, string searchpath, string searchfile)
        {
            int lv = 0;
            pGetAllDirFiles(path, thispath, searchpath, searchfile, dirlv, ref files, ref paths, ref lv);
        }

        /// <summary>获取指定目录下所有文件路径及空文件夹路径，分别返回到files及paths</summary>
        /// <param name="path">指定目录(物理路径)</param>
        /// <param name="dirlv">子目录最大深度</param>
        /// <param name="files">返回所有文件路径列表</param>
        /// <param name="paths">返回所有空文件夹路径列表</param>
        /// <param name="searchpath">要与path中的目录名匹配的搜索字符串</param>
        /// <param name="searchfile">要与path中的文件名匹配的搜索字符串</param>
        public static void GetAllDirFiles(string path, int dirlv, ref List<string> files, ref List<string> paths, string searchpath, string searchfile)
        {
            int lv = 0;
            pGetAllDirFiles(path, searchpath, searchfile, dirlv, ref files, ref paths, ref lv);
        }

        /// <summary>获取指定目录下(子目录深度最大1000级)所有文件相对路径及空文件夹相对路径，分别返回到files及paths</summary>
        /// <param name="path">指定目录(物理路径)</param>
        /// <param name="thispath">根路径</param>
        /// <param name="files">返回所有文件相对路径列表</param>
        /// <param name="paths">返回所有空文件夹相对路径列表</param>
        /// <param name="searchfile">要与path中的文件名匹配的搜索字符串</param>
        public static void GetAllDirFiles(string path, string thispath, ref List<string> files, ref List<string> paths, string searchfile)
        {
            int lv = 0;
            pGetAllDirFiles(path, thispath, "", searchfile, 1000, ref files, ref paths, ref lv);
        }

        /// <summary>获取指定目录下(子目录深度最大1000级)所有文件路径及空文件夹路径，分别返回到files及paths</summary>
        /// <param name="path">指定目录(物理路径)</param>
        /// <param name="files">返回所有文件路径列表</param>
        /// <param name="paths">返回所有空文件夹路径列表</param>
        /// <param name="searchfile">要与path中的文件名匹配的搜索字符串</param>
        public static void GetAllDirFiles(string path, ref List<string> files, ref List<string> paths, string searchfile)
        {
            int lv = 0;
            pGetAllDirFiles(path, "", searchfile, 1000, ref files, ref paths, ref lv);
        }

        /// <summary>获取指定目录下所有文件相对路径及空文件夹相对路径，分别返回到files及paths</summary>
        /// <param name="path">指定目录(物理路径)</param>
        /// <param name="thispath">根路径</param>
        /// <param name="dirlv">子目录最大深度</param>
        /// <param name="files">返回所有文件相对路径列表</param>
        /// <param name="paths">返回所有空文件夹相对路径列表</param>
        /// <param name="searchfile">要与path中的文件名匹配的搜索字符串</param>
        public static void GetAllDirFiles(string path, string thispath, int dirlv, ref List<string> files, ref List<string> paths, string searchfile)
        {
            int lv = 0;
            pGetAllDirFiles(path, thispath, "", searchfile, dirlv, ref files, ref paths, ref lv);
        }

        /// <summary>获取指定目录下所有文件路径及空文件夹路径，分别返回到files及paths</summary>
        /// <param name="path">指定目录(物理路径)</param>
        /// <param name="dirlv">子目录最大深度</param>
        /// <param name="files">返回所有文件路径列表</param>
        /// <param name="paths">返回所有空文件夹路径列表</param>
        /// <param name="searchfile">要与path中的文件名匹配的搜索字符串</param>
        public static void GetAllDirFiles(string path, int dirlv, ref List<string> files, ref List<string> paths, string searchfile)
        {
            int lv = 0;
            pGetAllDirFiles(path, "", searchfile, dirlv, ref files, ref paths, ref lv);
        }

        /// <summary>获取指定目录下所有文件相对路径及空文件夹相对路径，分别返回到files及paths</summary>
        /// <param name="path">指定目录(物理路径)</param>
        /// <param name="thispath">根路径</param>
        /// <param name="searchpath">要与path中的目录名匹配的搜索字符串</param>
        /// <param name="searchfile">要与path中的文件名匹配的搜索字符串</param>
        /// <param name="dirlv">子目录最大深度</param>
        /// <param name="files">返回所有文件相对路径列表</param>
        /// <param name="paths">返回所有空文件夹相对路径列表</param>
        /// <param name="lv">当前目录深度</param>
        private static void pGetAllDirFiles(string path, string thispath, string searchpath, string searchfile, int dirlv, ref List<string> files, ref List<string> paths, ref int lv)
        {
            lv++;
            if (lv > dirlv) 
            {
                return;
            }
            string[] subPaths;
            if (searchpath.Trim() == "")
            {
                subPaths = Directory.GetDirectories(path);
            }
            else 
            {
                subPaths = Directory.GetDirectories(path, searchpath);
            }
            foreach (string ph in subPaths)
            {
                pGetAllDirFiles(ph, thispath, searchpath, searchfile, dirlv, ref files, ref paths, ref lv);
            }
            string[] fs;
            if (searchfile.Trim() == "")
            {
                fs = Directory.GetFiles(path);
            }
            else
            {
                fs = Directory.GetFiles(path, searchfile);
            }
            foreach (string file in fs)
            {
                string sfile = file;
                sfile = sfile.Replace("/", "\\");
                sfile = sfile.Remove(0, thispath.Length);
                if (files.IndexOf(sfile) == -1)
                {
                    files.Add(sfile);
                }
            }
            if (subPaths.Length == fs.Length && fs.Length == 0)
            {
                path = path.Replace("/", "\\");
                path = path.Remove(0, thispath.Length);
                if (paths.IndexOf(path) == -1)
                {
                    paths.Add(path);
                }
            }
        }

        /// <summary>获取指定目录下所有文件路径及空文件夹路径，分别返回到files及paths</summary>
        /// <param name="path">指定目录(物理路径)</param>
        /// <param name="searchpath">要与path中的目录名匹配的搜索字符串</param>
        /// <param name="searchfile">要与path中的文件名匹配的搜索字符串</param>
        /// <param name="dirlv">子目录最大深度</param>
        /// <param name="files">返回所有文件路径列表</param>
        /// <param name="paths">返回所有空文件夹路径列表</param>
        /// <param name="lv">当前目录深度</param>
        private static void pGetAllDirFiles(string path, string searchpath, string searchfile, int dirlv, ref List<string> files, ref List<string> paths, ref int lv)
        {
            lv++;
            if (lv > dirlv)
            {
                return;
            }
            string[] subPaths;
            if (searchpath.Trim() == "")
            {
                subPaths = Directory.GetDirectories(path);
            }
            else
            {
                subPaths = Directory.GetDirectories(path, searchpath);
            }
            foreach (string ph in subPaths)
            {
                pGetAllDirFiles(ph, searchpath, searchfile, dirlv, ref files, ref paths, ref lv);
            }
            string[] fs;
            if (searchfile.Trim() == "")
            {
                fs = Directory.GetFiles(path);
            }
            else
            {
                fs = Directory.GetFiles(path, searchfile);
            }
            foreach (string file in fs)
            {
                string fstr = file.Replace("/","\\");
                if (files.IndexOf(fstr) == -1)
                {
                    files.Add(fstr);
                }
            }
            if (subPaths.Length == fs.Length && fs.Length == 0)
            {
                string pstr = path.Replace("/", "\\");
                if (paths.IndexOf(pstr) == -1) 
                {
                    paths.Add(pstr);
                }
            }
        }

        /// <summary>返回指定文件的MD5Hash码值</summary>
        /// <param name="path">文件路径</param>
        /// <returns>返回指定文件的MD5Hash码值</returns>
        public static string GetFileMD5Hash(string path)
        {
            string err="";
            return GetFileMD5Hash(path, ref err);
        }

        /// <summary>返回指定文件的MD5Hash码值</summary>
        /// <param name="path">文件路径</param>
        /// <param name="err">发生错误返回的错误信息</param>
        /// <returns>返回指定文件的MD5Hash码值</returns>
        public static string GetFileMD5Hash(string path, ref string err)
        {
            try
            {
                FileStream get_file = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                System.Security.Cryptography.MD5CryptoServiceProvider getHash = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] hash_byte = getHash.ComputeHash(get_file);
                string resule = System.BitConverter.ToString(hash_byte);
                resule = resule.Replace("-", "");
                return resule;
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
            return "";
        }

        /// <summary>返回指定文件的SHA1Hash码值</summary>
        /// <param name="path">文件路径</param>
        /// <returns>返回指定文件的SHA1Hash码值</returns>
        public static string GetFileSHA1Hash(string path)
        {
            string err="";
            return GetFileSHA1Hash(path, ref err);
        }

        /// <summary>返回指定文件的SHA1Hash码值</summary>
        /// <param name="path">文件路径</param>
        /// <param name="err">发生错误返回的错误信息</param>
        /// <returns>返回指定文件的SHA1Hash码值</returns>
        public static string GetFileSHA1Hash(string path, ref string err)
        {
            try
            {
                FileStream get_file = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                System.Security.Cryptography.SHA1CryptoServiceProvider getHash = new System.Security.Cryptography.SHA1CryptoServiceProvider();
                byte[] hash_byte = getHash.ComputeHash(get_file);
                string resule = System.BitConverter.ToString(hash_byte);
                resule = resule.Replace("-", "");
                return resule;
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
            return "";
        }

        /// <summary>返回当前程序运行路径</summary>
        /// <returns>返回当前程序运行路径</returns>
        public static string GetAssemblyPath()
        {
            string _CodeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            _CodeBase = _CodeBase.Substring(8, _CodeBase.Length - 8); // 8是 file:// 的长度   
            string[] arrSection = _CodeBase.Split(new char[] { '/' });
            string _FolderPath = "";
            for (int i = 0; i < arrSection.Length - 1; i++)
            {
                _FolderPath += arrSection[i] + "/";
            }
            return _FolderPath;
        }
    }
}


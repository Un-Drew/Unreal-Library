﻿using System;
using System.IO;
using UELib;
using UELib.Branch;
using UELib.Core;
using UELib.Decoding;

namespace Eliot.UELib.Benchmark
{
    public class UnrealTestArchive : IUnrealArchive
    {
        public UnrealTestArchive(UnrealPackage package, uint version, uint licenseeVersion = 0, uint ue4Version = 0, bool bigEndianCode = false)
        {
            Package = package;
            Version = version;
            LicenseeVersion = licenseeVersion;
            UE4Version = ue4Version;
            BigEndianCode = bigEndianCode;
        }

        public UnrealPackage Package { get; }
        public uint Version { get; }
        public uint LicenseeVersion { get; }
        public uint UE4Version { get; }
        public bool BigEndianCode { get; }
        public long LastPosition { get; set; }
    }
    
    /// Hackish workaround for the issue with UPackageStream requiring a file and path, so that we can perform stream tests without a package.
    public class UnrealTestStream : UnrealReader, IUnrealStream
    {
        public uint Version => _Archive.Version;
        public uint LicenseeVersion => _Archive.LicenseeVersion;
        public uint UE4Version => _Archive.UE4Version;
        public bool BigEndianCode => _Archive.BigEndianCode;
        
        public UnrealPackage Package => _Archive.Package;
        public UnrealReader UR => this;
        public UnrealWriter UW { get; }
        
        public IBufferDecoder Decoder { get; set; }
        public IPackageSerializer Serializer { get; set; }

        public void SetBranch(EngineBranch packageEngineBranch)
        {
            throw new NotImplementedException();
        }

        public UnrealTestStream(IUnrealArchive archive, Stream baseStream) : base(archive, baseStream)
        {
            _Archive = archive;
        }

        public string ReadASCIIString()
        {
            throw new NotImplementedException();
        }

        public int ReadObjectIndex()
        {
            throw new NotImplementedException();
        }

        public UObject ReadObject()
        {
            throw new NotImplementedException();
        }

        public UObject ParseObject(int index)
        {
            throw new NotImplementedException();
        }

        public new int ReadNameIndex()
        {
            throw new NotImplementedException();
        }

        public new int ReadNameIndex(out int num)
        {
            throw new NotImplementedException();
        }

        public string ParseName(int index)
        {
            throw new NotImplementedException();
        }

        public float ReadFloat()
        {
            throw new NotImplementedException();
        }

        public void Skip(int bytes)
        {
            throw new NotImplementedException();
        }

        public long Length => BaseStream.Length;
        public long Position
        {
            get => BaseStream.Position;
            set => BaseStream.Position = value;
        }

        public long AbsolutePosition
        {
            get => Position;
            set => Position = value;
        }

        public long LastPosition
        {
            get => BaseStream.Position;
            set => BaseStream.Position = value;
        }
        
        public long Seek(long offset, SeekOrigin origin)
        {
            return BaseStream.Seek(offset, origin);
        }

        public void SetBranch(IPackageSerializer packageSerializer)
        {
            throw new NotImplementedException();
        }
    }
}

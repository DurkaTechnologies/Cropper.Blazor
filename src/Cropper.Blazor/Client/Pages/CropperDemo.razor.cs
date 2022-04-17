﻿using Cropper.Blazor.Base;
using Cropper.Blazor.Components;
using Cropper.Blazor.Events.CropEndEvent;
using Cropper.Blazor.Events.CropEvent;
using Cropper.Blazor.Events.CropMoveEvent;
using Cropper.Blazor.Events.CropReadyEvent;
using Cropper.Blazor.Events.CropStartEvent;
using Cropper.Blazor.Events.ZoomEvent;
using Cropper.Blazor.Models;
using Cropper.Blazor.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace Cropper.Blazor.Client.Pages
{
    public partial class CropperDemo
    {
        private CropperComponent? cropperComponent;
        private Options options;
        private decimal? x;
        private decimal? y;
        private decimal? height;
        private decimal? width;
        private decimal? rotate;
        private decimal? scaleX;
        private decimal? scaleY;
        private CropBoxData? cropBoxData;
        private CropperData? cropperData;
        private ContainerData? containerData;
        private ImageData? imageData;
        private CanvasData? canvasData;

        protected override void OnInitialized()
        {
            cropBoxData = new CropBoxData();
            cropperData = new CropperData();
            containerData = new ContainerData();
            imageData = new ImageData();
            canvasData = new CanvasData();
            options = new Options()
            {
                Preview = ".img-preview",
                AspectRatio = (decimal)16 / 9,
                //DragMode =  DragMode.Crop.ToString()
            };
        }

        public void OnCropEndEvent(CropEndEvent cropEndEvent)
        {
            Console.WriteLine($"CropEndEvent, {cropEndEvent.ActionEvent}");
        }

        public void OnCropStartEvent(CropStartEvent cropStartEvent)
        {
            Console.WriteLine($"CropStartEvent, {cropStartEvent.ActionEvent}");
        }

        public void OnZoomEvent(ZoomEvent zoomEvent)
        {
            Console.WriteLine($"ZoomEvent, OldRatio: {zoomEvent.OldRatio}, Ratio: {zoomEvent.Ratio}");
        }

        public void OnCropMoveEvent(CropMoveEvent cropMoveEvent)
        {
            Console.WriteLine($"CropMoveEvent, {cropMoveEvent.ActionEvent}");
        }

        public void OnCropReadyEvent(CropReadyEvent cropReadyEvent)
        {
            Console.WriteLine("Cropper Is Ready");
        }

        public void OnLoadImageEvent()
        {
            Console.WriteLine("Image Is loaded");
        }

        public void OnCropEvent(CropEvent cropEvent)
        {
            x = cropEvent.X;
            y = cropEvent.Y;
            width = cropEvent.Width;
            height = cropEvent.Height;
            rotate = cropEvent.Rotate;
            scaleX = cropEvent.ScaleX;
            scaleY = cropEvent.ScaleY;
            Console.WriteLine($"CropEvent, X: {cropEvent.X}, Y: {cropEvent.Y}, " +
                $"Height: {cropEvent.Height}, Width: {cropEvent.Width}, " +
                $"ScaleX: {cropEvent.ScaleX}, ScaleY: {cropEvent.ScaleY}, Rotate: {cropEvent.Rotate}");
            StateHasChanged();
        }

        private void SetMoveDragMode()
        {
            cropperComponent?.SetDragMode(DragMode.Move);
        }

        private void SetCropDragMode()
        {
            cropperComponent?.SetDragMode(DragMode.Crop);
        }

        private void Zoom(decimal ratio)
        {
            cropperComponent?.Zoom(ratio);
        }

        public void ZoomTo(decimal ratio, decimal pivotX, decimal pivotY)
        {
            cropperComponent?.ZoomTo(ratio, pivotX, pivotY);
        }

        private void Move(decimal offsetX, decimal? offsetY)
        {
            cropperComponent?.Move(offsetX, offsetY);
        }

        public void MoveTo(decimal x, decimal? y)
        {
            cropperComponent?.MoveTo(x, y);
        }

        private void Rotate(decimal degree)
        {
            cropperComponent?.Rotate(degree);
        }

        private void ScaleX(decimal? scaleX)
        {
            cropperComponent?.ScaleX(scaleX ?? 0);
        }

        private void ScaleY(decimal? scaleY)
        {
            cropperComponent?.ScaleY(scaleY ?? 0);
        }

        public void Scale(decimal? scaleX, decimal? scaleY)
        {
            cropperComponent?.Scale(scaleX??0, scaleY??0);
        }

        private void Crop()
        {
            cropperComponent?.Crop();
        }

        private void Clear()
        {
            cropperComponent?.Clear();
        }

        private void Enable()
        {
            cropperComponent?.Enable();
        }

        private void Disable()
        {
            cropperComponent?.Disable();
        }

        private void Destroy()
        {
            cropperComponent?.Destroy();
        }

        public void SetAspectRatio(decimal aspectRatio)
        {
            cropperComponent?.SetAspectRatio(aspectRatio);
        }

        public void SetViewMode(ViewMode viewMode)
        {
            options.ViewMode = viewMode; 
            cropperComponent?.Destroy();
            cropperComponent?.InitCropper();
        }

        private void Reset()
        {
            cropperComponent?.Reset();
        }

        public void SetCropBoxData(SetCropBoxDataOptions cropBoxDataOptions)
        {
            cropperComponent?.SetCropBoxData(cropBoxDataOptions);
        }

        public void SetData(SetDataOptions setDataOptions)
        {
            cropperComponent?.SetData(setDataOptions);
        }

        public void SetCanvasData(SetCanvasDataOptions setCanvasDataOptions)
        {
            cropperComponent?.SetCanvasData(setCanvasDataOptions);
        }

        public async void GetCropBoxData()
        {
            cropBoxData = await cropperComponent.GetCropBoxData();
            StateHasChanged();
        }

        public async void GetData(bool rounded)
        {
            cropperData = await cropperComponent.GetData(rounded);
            StateHasChanged();
        }

        public async void GetContainerData()
        {
            containerData = await cropperComponent.GetContainerData();
            StateHasChanged();
        }

        public async void GetImageData()
        {
            imageData = await cropperComponent.GetImageData();
            StateHasChanged();
        }

        public async void GetCanvasData()
        {
            canvasData = await cropperComponent.GetCanvasData();
            StateHasChanged();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {

            }
            await base.OnAfterRenderAsync(firstRender);
        }
    }
}

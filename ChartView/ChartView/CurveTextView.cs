//using System;
//using CoreGraphics;
//using UIKit;

//namespace ChartView.ChartView
//{
//    public class CurveTextView : UIView
//    {


//        public override void Draw(CoreGraphics.CGRect rect)
//        {
//            base.Draw(rect);

//            if (this.font == NULL || this.text == NULL) 
//        return;
    
//        // Initialize the text matrix to a known value
//            var context = UIGraphics.GetCurrentContext();
//        //Reset the transformation
//        //Doing this means you have to reset the contentScaleFactor to 1.0
//            CGAffineTransform t0 = context.GetCTM();
//            context.SetShadow(new CGSize(this.xOffsetShadow, this.yOffsetShadow), this.blurShadow, this.shadowColor.CGColor);

//            nfloat xScaleFactor = t0.a > 0 ? t0.a : -t0.a;
//    nfloat yScaleFactor = t0.d > 0 ? t0.d : -t0.d;
//            t0 =trans(t0);
//    if (xScaleFactor != 1.0 || yScaleFactor != 1.0)
//                t0 = CGAffineTransform.Scale(t0, xScaleFactor, yScaleFactor);
    
//            context.ConcatCTM( t0);
    
//            context.TextMatrix=CGAffineTransform.MakeIdentity();
    
//    if(ARCVIEW_DEBUG_MODE){
//            // Draw a black background (debug)
//        CGContextSetFillColorWithColor(context, [UIColor blackColor].CGColor);
//                context.SetFillColor(this.Layer.bounds);
//    }
    
//    NSAttributedString *attStr = this.attributedString;
//    CFAttributedStringRef asr = (CFAttributedStringRef)attStr;
//    CTLineRef line = CTLineCreateWithAttributedString(asr);
//    assert(line != NULL);
    
//    CFIndex glyphCount = CTLineGetGlyphCount(line);
//    if (glyphCount == 0) {
//        CFRelease(line);
//        return;
//    }
    
//    GlyphArcInfo *  glyphArcInfo = (GlyphArcInfo*)calloc(glyphCount, sizeof(GlyphArcInfo));
//    PrepareGlyphArcInfo(line, glyphCount, glyphArcInfo, _arcSize);
    
//        // Move the origin from the lower left of the view nearer to its center.
//    CGContextSaveGState(context);
    
//    CGContextTranslateCTM(context, CGRectGetMidX(rect)+_shiftH, CGRectGetMidY(rect)+_shiftV);
    
//    if(ARCVIEW_DEBUG_MODE){
//            // Stroke the arc in red for verification.
//        CGContextBeginPath(context);
//        CGContextAddArc(context, 0.0, 0.0, this.radius, M_PI_2+_arcSize/2.0, M_PI_2-_arcSize/2.0, 1);
//        CGContextSetRGBStrokeColor(context, 1.0, 0.0, 0.0, 1.0);
//        CGContextStrokePath(context);
//    }
    
//        // Rotate the context 90 degrees counterclockwise (per 180 degrees)
//    CGContextRotateCTM(context, _arcSize/2.0);
    
//        // Now for the actual drawing. The angle offset for each glyph relative to the previous glyph has already been calculated; with that information in hand, draw those glyphs overstruck and centered over one another, making sure to rotate the context after each glyph so the glyphs are spread along a semicircular path.
    
//    CGPoint textPosition = CGPointMake(0.0, this.radius);
//    CGContextSetTextPosition(context, textPosition.x, textPosition.y);
    
//    CFArrayRef runArray = CTLineGetGlyphRuns(line);
//    CFIndex runCount = CFArrayGetCount(runArray);
    
//    CFIndex glyphOffset = 0;
//    CFIndex runIndex = 0;
//    for (; runIndex < runCount; runIndex++) {
//        CTRunRef run = (CTRunRef)CFArrayGetValueAtIndex(runArray, runIndex);
//        CFIndex runGlyphCount = CTRunGetGlyphCount(run);
//        Boolean drawSubstitutedGlyphsManually = false;
//        CTFontRef runFont = CFDictionaryGetValue(CTRunGetAttributes(run), kCTFontAttributeName);
        
//            // Determine if we need to draw substituted glyphs manually. Do so if the runFont is not the same as the overall font.
//        if (this.dimsSubstitutedGlyphs && ![this.font isEqual:(UIFont *)runFont]) {
//            drawSubstitutedGlyphsManually = true;
//        }
        
//        CFIndex runGlyphIndex = 0;
//        for (; runGlyphIndex < runGlyphCount; runGlyphIndex++) {
//            CFRange glyphRange = CFRangeMake(runGlyphIndex, 1);
//            CGContextRotateCTM(context, -(glyphArcInfo[runGlyphIndex + glyphOffset].angle));
            
//                // Center this glyph by moving left by half its width.
//            nfloat glyphWidth = glyphArcInfo[runGlyphIndex + glyphOffset].width;
//            nfloat halfGlyphWidth = glyphWidth / 2.0;
//            CGPoint positionForThisGlyph = CGPointMake(textPosition.x - halfGlyphWidth, textPosition.y);
            
//                // Glyphs are positioned relative to the text position for the line, so offset text position leftwards by this glyph's width in preparation for the next glyph.
//            textPosition.x -= glyphWidth;
            
//            CGAffineTransform textMatrix = CTRunGetTextMatrix(run);
//            textMatrix.tx = positionForThisGlyph.x;
//            textMatrix.ty = positionForThisGlyph.y;
//            CGContextSetTextMatrix(context, textMatrix);
            
//            if (!drawSubstitutedGlyphsManually) {
//                CTRunDraw(run, context, glyphRange);
//            } 
//            else {
//                    // We need to draw the glyphs manually in this case because we are effectively applying a graphics operation by setting the context fill color. Normally we would use kCTForegroundColorAttributeName, but this does not apply as we don't know the ranges for the colors in advance, and we wanted demonstrate how to manually draw.
//                CGFontRef cgFont = CTFontCopyGraphicsFont(runFont, NULL);
//                CGGlyph glyph;
//                CGPoint position;
                
//                CTRunGetGlyphs(run, glyphRange, &glyph);
//                CTRunGetPositions(run, glyphRange, &position);
                
//                CGContextSetFont(context, cgFont);
//                CGContextSetFontSize(context, CTFontGetSize(runFont));
//                CGContextSetRGBFillColor(context, 0.25, 0.25, 0.25, 0.5);
//                CGContextShowGlyphsAtPositions(context, &glyph, &position, 1);
                
//                CFRelease(cgFont);
//            }
            
//                // Draw the glyph bounds 
//            if ((this.showsGlyphBounds) != 0) {
//                CGRect glyphBounds = CTRunGetImageBounds(run, context, glyphRange);
                
//                CGContextSetRGBStrokeColor(context, 0.0, 0.0, 1.0, 1.0);
//                CGContextStrokeRect(context, glyphBounds);
//            }
//                // Draw the bounding boxes defined by the line metrics
//            if ((this.showsLineMetrics) != 0) {
//                CGRect lineMetrics;
//                nfloat ascent, descent;
                
//                CTRunGetTypographicBounds(run, glyphRange, &ascent, &descent, NULL);
                
//                    // The glyph is centered around the y-axis
//                lineMetrics.origin.x = -halfGlyphWidth;
//                lineMetrics.origin.y = positionForThisGlyph.y - descent;
//                lineMetrics.size.width = glyphWidth; 
//                lineMetrics.size.height = ascent + descent;
                
//                CGContextSetRGBStrokeColor(context, 0.0, 1.0, 0.0, 1.0);
//                CGContextStrokeRect(context, lineMetrics);
//            }
//        }
        
//        glyphOffset += runGlyphCount;
//    }
    
//    CGContextSetFillColorWithColor(context, [UIColor clearColor].CGColor);
//    CGContextSetAlpha(context,0.0);
//    CGContextFillRect(context, rect);
    
//    CGContextRestoreGState(context);
    
//    free(glyphArcInfo);
//    CFRelease(line);    
//        }
//    }
//}
